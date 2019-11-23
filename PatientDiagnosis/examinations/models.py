from django.db import models


class Examination(models.Model):
    patient_age = models.PositiveIntegerField(default=0)
    pulse = models.PositiveIntegerField(default=0)
