using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientDiagnosis.Examinations.Service.Models.Entities;

namespace PatientDiagnosis.Examinations.Service.Models.Maps
{
    public class ExaminationMap
    {
        public ExaminationMap(EntityTypeBuilder<Examination> entityBuilder)
        {
            entityBuilder
                .HasKey(examination => examination.Id);

            entityBuilder.Property(examination => examination.PatientId)
                .HasColumnName("patient_id");

            entityBuilder.Property(examination => examination.Infraction)
                .HasColumnName("infraction")
                .IsRequired();

            entityBuilder.Property(examination => examination.InitialDbp)
                .HasColumnName("initial_dbp")
                .IsRequired();

            entityBuilder.Property(examination => examination.AtrialFibrillation)
                .HasColumnName("atrial_fibrillation")
                .IsRequired();

            entityBuilder.Property(examination => examination.BodyWeakness)
                .HasColumnName("body_weakness")
                .IsRequired();

            entityBuilder.Property(examination => examination.FirstTia)
                .HasColumnName("first_tia")
                .IsRequired();

            entityBuilder.Property(examination => examination.GaitDisturb)
                .HasColumnName("gait_disturb")
                .IsRequired();

            entityBuilder.Property(examination => examination.HighGlucose)
                .HasColumnName("high_glucose")
                .IsRequired();

            entityBuilder.Property(examination => examination.SpeechDif)
                .HasColumnName("speech_dif")
                .IsRequired();

            entityBuilder.Property(examination => examination.Vertigo)
                .HasColumnName("vertigo")
                .IsRequired();
        }
    }
}
