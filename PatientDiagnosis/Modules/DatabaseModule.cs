using Autofac;
using PatientDiagnosis.Patients.Service.Models;

namespace PatientDiagnosis.Patients.Service.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PatientDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
