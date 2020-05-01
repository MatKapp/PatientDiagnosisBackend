using Autofac;
using PatientDiagnosis.Common.Services.Interfaces;
using PatientDiagnosis.Patients.Service.Services;
using PatientDiagnosis.Services;
using PatientDiagnosis.Services.Interfaces;

namespace PatientDiagnosis.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ExaminationService>()
                .As<IExaminationService>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQHandler>()
                .As<IRabbitMQHandler>()
                .SingleInstance();
        }
    }
}
