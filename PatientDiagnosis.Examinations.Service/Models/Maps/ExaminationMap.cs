using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientDiagnosis.Common.Models.Entities;

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
                .HasColumnName("infraction");

            entityBuilder.Property(examination => examination.InitialDbp)
                .HasColumnName("initial_dbp");

            entityBuilder.Property(examination => examination.AtrialFibrillation)
                .HasColumnName("atrial_fibrillation");

            entityBuilder.Property(examination => examination.BodyWeakness)
                .HasColumnName("body_weakness");

            entityBuilder.Property(examination => examination.FirstTia)
                .HasColumnName("first_tia");

            entityBuilder.Property(examination => examination.GaitDisturb)
                .HasColumnName("gait_disturb");

            entityBuilder.Property(examination => examination.HighGlucose)
                .HasColumnName("high_glucose");

            entityBuilder.Property(examination => examination.SpeechDif)
                .HasColumnName("speech_dif");

            entityBuilder.Property(examination => examination.Vertigo)
                .HasColumnName("vertigo");
        }
    }
}
