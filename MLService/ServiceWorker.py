import RabbitMQAdapter
import pickle
import numpy as np
import json
import math

examination_queue_name = 'examination'
examination_prediction_queue_name = 'examination.prediction'
host = 'localhost'
model_path = './RFtest.sav'
loaded_model = pickle.load(open(model_path, 'rb'))


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
    a[29] = 0.0 if deserializedBody["Infraction"] is None else deserializedBody["Infraction"] #my_infract
    a[32] = 0.0 if deserializedBody["BodyWeakness"] is None else deserializedBody["BodyWeakness"] #my_weakness
    a[33] = 0.0 if deserializedBody["GaitDisturb"] is None else deserializedBody["GaitDisturb"] #my_gait
    a[34] = 0.0 if deserializedBody["Vertigo"] is None else deserializedBody["Vertigo"] #my_vertigo_syncope
    a[35] = 0.0 if deserializedBody["SpeechDif"] is None else deserializedBody["SpeechDif"] #my_lang_speech
    a[36] = 0.0 if deserializedBody["AtrialFibrillation"] is None else deserializedBody["AtrialFibrillation"] #my_afib
    return a


def callback(ch, method, properties, body):
    decodedBody = body.decode("utf-8")
    deserializedBody = json.loads(decodedBody)
    experimentArray = createArrayFromBody(deserializedBody)
    prediction = loaded_model.predict_proba([experimentArray])
    response = {"Id": deserializedBody["Id"], "FirstClassPrediction": round(prediction[0][0], 2), "SecondClassPrediction": round(prediction[0][1], 2)}
    RabbitMQAdapter.send_message(ch, examination_prediction_queue_name, json.dumps(response))


if __name__ == '__main__':
    channel = RabbitMQAdapter.create_channel(host)
    channel.queue_declare(queue=examination_prediction_queue_name)
    channel.queue_bind(queue=examination_prediction_queue_name, exchange='amq.direct', routing_key=examination_prediction_queue_name)
    RabbitMQAdapter.subscribe_to_queue(channel, examination_queue_name, callback)