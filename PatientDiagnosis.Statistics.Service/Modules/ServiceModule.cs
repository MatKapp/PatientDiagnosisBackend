using Autofac;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Examinations.Service.Services;
using PatientDiagnosis.Examinations.Service.Services.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ExaminationService>()
                .As<IExaminationService>()
                .SingleInstance();
        }
    }
}
