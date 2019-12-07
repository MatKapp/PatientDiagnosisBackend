from django.shortcuts import render
from django.http import HttpResponse
from rest_framework import mixins, viewsets
from examinations import models


def index(request):
    return HttpResponse("Hello world- examinations")

class ExaminationView(viewsets.GenericViewSet, mixins.ListModelMixin):
    queryset = models.Examination.objects.all()
