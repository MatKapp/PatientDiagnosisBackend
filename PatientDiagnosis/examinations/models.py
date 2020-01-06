from django.db import models


class Examination(models.Model):
    atrial_fibrillation = models.BooleanField(default=False)
    initial_dbp = models.PositiveIntegerField(default=0)
    speech_dif = models.BooleanField(default=False)
    gait_disturb = models.BooleanField(default=False)
    body_weakness = models.BooleanField(default=False)
    high_glucose = models.BooleanField(default=False)
    first_tia = models.BooleanField(default=False)
    vertigo = models.BooleanField(default=False)
    infraction = models.PositiveIntegerField(default=0)
