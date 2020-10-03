using System;

namespace PatientDiagnosis.Examinations.Service.Models.Entities
{
    public class ExaminationPresentation
    {
        public long Id { get; set; }
        public int? PatientId { get; set; }
        public int Infraction { get; set; } //infraction (obumarcie komórek/tkanek) on computed tomography
        public int InitialDbp { get; set; } //diastolic blood pressure
        public string AtrialFibrillation { get; set; } //very rapid uncoordinated contractions of the atria of the heart
        public string BodyWeakness { get; set; }
        public string FirstTia { get; set; }
        public string GaitDisturb { get; set; } //Gait(chód) abnormality
        public string HighGlucose { get; set; }
        public string SpeechDif { get; set; } //speech difficulties
        public string Vertigo { get; set; } //zawrót głowy
        public float FirstClassPrediction { get; set; }
        public float SecondClassPrediction { get; set; }
        public string TiaInTwoWeeksOccured { get; set; }
    }
}
