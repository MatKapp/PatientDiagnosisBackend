from django.http import HttpResponse
from django.shortcuts import render
from patients import models, serializers
from rest_framework import mixins, viewsets, response, status
from rest_framework.decorators import action


def index(request):
    return HttpResponse("Hello world-patients")

class PatientView(viewsets.GenericViewSet,
                    mixins.CreateModelMixin,
                    mixins.ListModelMixin,
                    mixins.RetrieveModelMixin,
                    mixins.UpdateModelMixin):
                    
    serializer_class = serializers.PatientSerializer
    queryset = models.Patient.objects.all()