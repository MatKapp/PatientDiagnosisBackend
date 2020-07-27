using Microsoft.EntityFrameworkCore;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Models.Maps;

namespace PatientDiagnosis.Examinations.Service.Models
{
    public class ExaminationDbContext : DbContext
    {
        public ExaminationDbContext(DbContextOptions<ExaminationDbContext> options) : base(options) { }
        public DbSet<Examination> Examinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ExaminationsSchema(modelBuilder);
        }

        private void ExaminationsSchema(ModelBuilder modelBuilder)
        {
            new ExaminationMap(modelBuilder.Entity<Examination>());
        }
    }
}
