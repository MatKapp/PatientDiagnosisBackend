namespace PatientDiagnosis.Examinations.Service.Models.Entities
{
    public class Examination
    {
        public long Id { get; set; }
        public int? PatientId { get; set; }
        public int Infraction { get; set; } //infraction (obumarcie komórek/tkanek) on computed tomography
        public int InitialDbp { get; set; } //diastolic blood pressure
        public bool AtrialFibrillation { get; set; } //very rapid uncoordinated contractions of the atria of the heart
        public bool BodyWeakness { get; set; }
        public bool FirstTia { get; set; }
        public bool GaitDisturb { get; set; } //Gait(chód) abnormality
        public bool HighGlucose { get; set; }
        public bool SpeechDif { get; set; } //speech difficulties
        public bool Vertigo { get; set; } //zawrót głowy
        public float FirstClassPrediction { get; set; }
        public float SecondClassPrediction { get; set; }
        public bool TiaInTwoWeeksOccured { get; set; }
    }
}
