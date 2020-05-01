using Autofac;
using PatientDiagnosis.Models;

namespace PatientDiagnosis.Modules
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
