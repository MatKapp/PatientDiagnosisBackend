using Autofac;
using PatientDiagnosis.Examinations.Service.Models;

namespace PatientDiagnosis.Examinations.Service.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ExaminationDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
