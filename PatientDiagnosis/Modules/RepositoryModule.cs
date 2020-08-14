using Autofac;
using PatientDiagnosis.Patients.Service.Repositories;
using PatientDiagnosis.Patients.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Patients.Service.Modules
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
