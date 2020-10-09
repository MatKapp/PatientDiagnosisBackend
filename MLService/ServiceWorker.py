import RabbitMQAdapter
import pickle
import numpy as np
import pandas
import json
import math

examination_queue_name = 'examination'
examination_prediction_queue_name = 'examination.prediction'
host = 'localhost'
model1_path = './0 model.sav'
model2_path = './1 model.sav'
model3_path = './2 model.sav'

model1 = pickle.load(open(model1_path, 'rb'))
model2 = pickle.load(open(model2_path, 'rb'))
model3 = pickle.load(open(model3_path, 'rb'))

model1IndexList = list(model1['preprocessor'].transformers_[0][2])
model2IndexList = list(model2['preprocessor'].transformers_[0][2])
model3IndexList = list(model3['preprocessor'].transformers_[0][2])

model1IndexSet = set(model1['preprocessor'].transformers_[0][2])
model2IndexSet = set(model2['preprocessor'].transformers_[0][2])
model3IndexSet = set(model3['preprocessor'].transformers_[0][2])

currentProcessingModel = 0

group1 = ['pmedhis_hyp', 'pmedhis_cad', 'pmedhis_af', 'pmedhis_pvd', 'pmedhis_diab', 'pmedhis_kps', 'pmedhis_smoker', 'pmedhis_cs', 'pmedhis_chf', 'pmedhis_hchol', 'pmedhis_dem', 'pmedhis_vhd', 'med_ibup_last_7days', 'my_infarct', 'inittia_numpast']
group2 = ['temperature', 'hr_rate', 'sbp', 'dbp', 'sa02', 'dursymptoms', 'my_sensation', 'my_weakness', 'my_gait', 'my_vertigo_syncope', 'my_lang_speech', 'my_afib', 'uni_weakness_l', 'uni_weakness_r', 'aphasia']
group3 = ['peter_flag', 'wbcvalue', 'hgbvalue', 'pltvalue', 'creatinevalue', 'glucosevalue', 'ckvalue', 'tntvalue', 'img_abn_l', 'img_abn_r']


class NoneSampler(object):
    def sample(self, X, y):
        return X, y

    def fit(self, X, y):
        return self

    def fit_resample(self, X, y):
        return self.sample(X, y)


def createArrayFromBody(deserializedBody):
    a = np.full(64, dtype=float, fill_value=0.0)
    a[6] = 0.0 if deserializedBody["InitialDbp"] is None else deserializedBody["InitialDbp"] #dbp
    # a[29] = 0.0 if deserializedBody["Infraction"] is None else deserializedBody["Infraction"] #my_infract
    # a[32] = 0.0 if deserializedBody["BodyWeakness"] is None else deserializedBody["BodyWeakness"] #my_weakness
    # a[33] = 0.0 if deserializedBody["GaitDisturb"] is None else deserializedBody["GaitDisturb"] #my_gait
    # a[34] = 0.0 if deserializedBody["Vertigo"] is None else deserializedBody["Vertigo"] #my_vertigo_syncope
    # a[35] = 0.0 if deserializedBody["SpeechDif"] is None else deserializedBody["SpeechDif"] #my_lang_speech
    # a[36] = 0.0 if deserializedBody["AtrialFibrillation"] is None else deserializedBody["AtrialFibrillation"] #my_afib
    return a


def camel_to_snake(s):
    return ''.join(['_'+c.lower() if c.isupper() else c for c in s]).lstrip('_')

def change_keys_to_snake(dictionary):
    keys_copy = list(dictionary.keys())
    for key in keys_copy:
        dictionary[camel_to_snake(key)] = dictionary.pop(key)
    return dictionary


def callback(ch, method, properties, body):
    decodedBody = body.decode("utf-8")
    dictionary_with_none = json.loads(decodedBody)
    dictionary_with_none = change_keys_to_snake(dictionary_with_none)
    dictionary = {k: v for k, v in dictionary_with_none.items() if v is not None}
    dictionaryKeysSet = set(dictionary.keys())
    finished = False
    prediction = None

    val1 = len(dictionaryKeysSet.intersection(model1IndexSet.union(model2IndexSet).union(model3IndexSet))) / len(
            model1IndexSet.union(model2IndexSet).union(model3IndexSet))

    val2 = len(dictionaryKeysSet.intersection(model1IndexSet.union(model2IndexSet))) / len(
            model1IndexSet.union(model2IndexSet))

    if len(dictionaryKeysSet.intersection(model1IndexSet.union(model2IndexSet).union(model3IndexSet))) / len(
            model1IndexSet.union(model2IndexSet).union(model3IndexSet)) > .75:
        finished = True
        a = np.full(len(model3IndexList), dtype=float, fill_value=None)
        a = fill_for_model(dictionary, dictionary.keys(), model3IndexSet, model3IndexList, a)
        index = model3['preprocessor'].transformers_[0][2]
        df = pandas.DataFrame(data=[a], columns=index)
        prediction = model3.predict_proba(df)
        print('3 used')

    if not finished and len(dictionaryKeysSet.intersection(model1IndexSet.union(model2IndexSet))) / len(
            model1IndexSet.union(model2IndexSet)) > .75:
        finished = True
        a = np.full(len(model2IndexList), dtype=float, fill_value=None)
        a = fill_for_model(dictionary, dictionary.keys(), model2IndexSet, model2IndexList, a)
        index = model2['preprocessor'].transformers_[0][2]
        df = pandas.DataFrame(data=[a], columns=index)
        prediction = model2.predict_proba(df)
        print('2 used')

    if not finished:
        a = np.full(len(model1IndexList), dtype=float, fill_value=None)
        a = fill_for_model(dictionary, dictionary.keys(), model1IndexSet, model1IndexList, a)
        index = model1['preprocessor'].transformers_[0][2]
        df = pandas.DataFrame(data=[a], columns=index)
        prediction = model1.predict_proba(df)
        print('1 used')

    response = {"Id": dictionary["id"], "FirstClassPrediction": round(prediction[0][0], 2), "SecondClassPrediction": round(prediction[0][1], 2)}
    RabbitMQAdapter.send_message(ch, examination_prediction_queue_name, json.dumps(response))


def fill_for_model(dictionary, keys, indexSet, indexList, arrayToFill):
    for key in keys:
        if key in indexSet:
            arrayToFill[indexList.index(key)] = dictionary[key]
    return arrayToFill


if __name__ == '__main__':

    channel = RabbitMQAdapter.create_channel(host)
    channel.queue_declare(queue=examination_prediction_queue_name)
    channel.queue_bind(queue=examination_prediction_queue_name, exchange='amq.direct', routing_key=examination_prediction_queue_name)
    RabbitMQAdapter.subscribe_to_queue(channel, examination_queue_name, callback)