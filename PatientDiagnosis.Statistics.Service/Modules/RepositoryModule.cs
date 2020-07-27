using Autofac;
using PatientDiagnosis.Examinations.Service.Repositories;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ExaminationRepository>()
                .As<IExaminationRepository>();
        }
    }
}
