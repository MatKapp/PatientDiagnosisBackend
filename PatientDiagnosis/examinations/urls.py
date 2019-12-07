from rest_framework.routers import DefaultRouter

from . import views

router = DefaultRouter()
router.register(r'examination', views.ExaminationView, basename='examination')

urlpatterns = router.urls