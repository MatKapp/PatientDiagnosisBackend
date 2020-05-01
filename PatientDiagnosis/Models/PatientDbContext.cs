using Microsoft.EntityFrameworkCore;
using PatientDiagnosis.Models.Maps;
using System;

namespace PatientDiagnosis.Models
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientsSchema(modelBuilder);
        }

        private void PatientsSchema(ModelBuilder modelBuilder)
        {
            new PatientMap(modelBuilder.Entity<Patient>());
        }
    }
}
