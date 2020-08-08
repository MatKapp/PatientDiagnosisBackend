namespace PatientDiagnosis.Examinations.Service.Models.Entities
{
    public class Examination
    {
        public long Id { get; set; }
        public int? PatientId { get; set; }
        public int Infraction { get; set; }
        public int InitialDbp { get; set; }
        public bool AtrialFibrillation { get; set; }
        public bool BodyWeakness { get; set; }
        public bool FirstTia { get; set; }
        public bool GaitDisturb { get; set; }
        public bool HighGlucose { get; set; }
        public bool SpeechDif { get; set; }
        public bool Vertigo { get; set; }
        public float FirstClassPrediction { get; set; }
        public float SecondClassPrediction { get; set; }
        public bool TiaInTwoWeeksOccured { get; set; }
    }
}
