from rest_framework.routers import DefaultRouter

from . import views

router = DefaultRouter()
router.register(r'', views.ExaminationView, basename='examination')

urlpatterns = router.urls