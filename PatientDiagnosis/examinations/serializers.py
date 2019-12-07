from rest_framework import serializers

from examinations import models

class ExaminationSerializer(serializers.ModelSerializer):
    class Meta:
        model = models.Examination
        fields =('id', 'pulse')