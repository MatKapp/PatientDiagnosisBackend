using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PatientDiagnosis.Examinations.Service.Models.Maps
{
    public class ExaminationMap
    {
        public ExaminationMap(EntityTypeBuilder<Examination> entityBuilder)
        {
            entityBuilder
                .HasKey(examination => examination.Id);
            
            entityBuilder.Property(examination => examination.Pulse)
                .HasColumnName("pulse")
                .IsRequired();
        }
    }
}
