from django.db import models

from examinations.models import Examination


class Patient(models.Model):
    surname = models.CharField(max_length=100)
    age = models.PositiveIntegerField(default=0)
    examination = models.ForeignKey(Examination, on_delete=models.DO_NOTHING, related_name='patients')