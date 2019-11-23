from django.db import models


class Examination(models.Model):
    pulse = models.PositiveIntegerField(default=0)
