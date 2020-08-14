using Autofac;
using PatientDiagnosis.Common.Architecture;
using PatientDiagnosis.Common.Architecture.Interfaces;

namespace PatientDiagnosis.Common.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RabbitMqSendingService>()
                .As<IRabbitMqSendingService>()
                .SingleInstance();
        }
    }
}
