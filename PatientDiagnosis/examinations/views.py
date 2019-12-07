from django.http import HttpResponse
from django.shortcuts import render
from examinations import models, serializers
from rest_framework import mixins, viewsets, response, status
from rest_framework.decorators import action


def index(request):
    return HttpResponse("Hello world- examinations")

class ExaminationView(viewsets.GenericViewSet,
                    mixins.CreateModelMixin,
                    mixins.ListModelMixin,
                    mixins.RetrieveModelMixin,
                    mixins.UpdateModelMixin):

    serializer_class = serializers.ExaminationSerializer
    queryset = models.Examination.objects.all()
