using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PatientDiagnosis.Patients.Service.Models.Maps
{
    public class PatientMap
    {
        public PatientMap(EntityTypeBuilder<Patient> entityBuilder)
        {
            entityBuilder
                .HasKey(patient => patient.Id);
            
            entityBuilder.Property(patient => patient.Surname)
                .HasColumnName("patient_surname")
                .IsRequired();

            entityBuilder.Property(patient => patient.Age)
                .HasColumnName("patient_age")
                .IsRequired();
                
        }
    }
}
