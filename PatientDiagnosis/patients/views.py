from django.http import HttpResponse
from django.shortcuts import render
from patients import models, serializers
from rest_framework import mixins, viewsets, response, status
from rest_framework.decorators import action


def index(request):
    return HttpResponse("Hello world-patients")

class PatientView(viewsets.GenericViewSet, mixins.ListModelMixin):
    serializer_class = serializers.PatientSerializer
    queryset = models.Patient.objects.all()

    @action(detail=True, methods=['post'])
    def post(self, request, *args, **kwargs):
        serializer = self.get_serializer(data = request.data)
        serializer.is_valid(raise_exception=True)
        serializer.save()
        return response.Response(data=serializer.data, status=status.HTTP_201_CREATED)