from rest_framework import serializers

from patients import models

class PatientSerializer(serializers.ModelSerializer):
    class Meta:
        model = models.Patient
        fields =('id', 'surname', 'age', 'examination')