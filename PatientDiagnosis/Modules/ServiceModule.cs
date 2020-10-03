using Autofac;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Patients.Service.Services;

namespace PatientDiagnosis.Patients.Service.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RabbitMQHandler>()
                .As<IRabbitMQHandler>()
                .SingleInstance();
        }
    }
}
