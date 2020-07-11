using Autofac;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Patients.Service.Services;
using PatientDiagnosis.Patients.Service.Services.Interfaces;

namespace PatientDiagnosis.Patients.Service.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PatientService>()
                .As<IPatientService>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQHandler>()
                .As<IRabbitMQHandler>()
                .SingleInstance();
        }
    }
}
