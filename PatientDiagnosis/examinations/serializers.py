from rest_framework import serializers

from examinations import models

class ExaminationSerializer(serializers.ModelSerializer):
    class Meta:
        model = models.Examination
        fields =\
        (
            'id',
            'atrial_fibrillation',
            'initial_dbp',
            'speech_dif',
            'gait_disturb',
            'body_weakness',
            'high_glucose',
            'first_tia',
            'vertigo',
            'infraction'
        )