using Autofac;
using PatientDiagnosis.Repositories;
using PatientDiagnosis.Repositories.Interfaces;

namespace PatientDiagnosis.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PatientRepository>()
                .As<IPatientRepository>();
        }
    }
}
