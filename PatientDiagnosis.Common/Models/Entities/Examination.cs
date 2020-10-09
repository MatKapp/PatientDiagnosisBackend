using System;

namespace PatientDiagnosis.Common.Models.Entities
{
    public class Examination
    {
        public long Id { get; set; }
        public int? PatientId { get; set; }

        //domographics (data from Patient) and medical history
        #region medical history
        public bool? PmedhisHyp { get; set; }
        public bool? PmedhisCad { get; set; }
        public bool? PmedhisAf { get; set; }
        public bool? PmedhisPvd { get; set; }
        public bool? PmedhisDiab { get; set; }
        public bool? PmedhisKps { get; set; }
        public bool? PmedhisSmoker { get; set; }
        public bool? PmedhisCs { get; set; }
        public bool? PmedhisChf { get; set; }
        public bool? PmedhisHchol { get; set; }
        public bool? PmedhisDem { get; set; }
        public bool? PmedhisVhd { get; set; }
        public int? MedAsa { get; set; }
        public int? MedDipy { get; set; }
        public int? MedClop { get; set; }
        public int? MedStat { get; set; }
        public int? MedAnti { get; set; }
        public int? MedCoum { get; set; }
        public bool? MedIbupLast7days { get; set; }
        public int? MyInfarct { get; set; }
        public int? InittiaNumpast { get; set; } // 0-30
        #endregion
        //signs and symptoms
        public int? Temperature { get; set; }
        public int? HrRate { get; set; }
        public int? Sbp { get; set; }
        public int? Dbp { get; set; }
        public int? Sa02 { get; set; }
        public int? Dursymptoms { get; set; }
        public bool? MySensation { get; set; }
        public bool? MyWeakness { get; set; }
        public bool? MyGait { get; set; }
        public bool? MyVertigo_syncope { get; set; }
        public bool? MyLang_speech { get; set; }
        public bool? MyAfib { get; set; }
        public bool? UniWeaknessL { get; set; }
        public bool? UniWeaknessR { get; set; }
        public bool? Aphasia { get; set; }
        //diagnostic testing

        public bool? PeterFlag { get; set; }
        public float? Wbcvalue { get; set; }
        public int? Hgbvalue { get; set; }
        public int? Pltvalue { get; set; }
        public int? Creatinevalue { get; set; }
        public float? Glucosevalue { get; set; }
        public int? Ckvalue { get; set; }
        public float? Tntvalue { get; set; }
        public int? Ecgtype { get; set; }
        public bool? ImgAbnL { get; set; }
        public bool? ImgAbnR { get; set; }
        public int? Infraction { get; set; } //infraction (obumarcie komórek/tkanek) on computed tomography
        public int? InitialDbp { get; set; } //diastolic blood pressure
        public bool? AtrialFibrillation { get; set; } //very rapid uncoordinated contractions of the atria of the heart
        public bool? BodyWeakness { get; set; }
        public bool? FirstTia { get; set; }
        public bool? GaitDisturb { get; set; } //Gait(chód) abnormality
        public bool? HighGlucose { get; set; }
        public bool? SpeechDif { get; set; } //speech difficulties
        public bool? Vertigo { get; set; } //zawrót głowy
        public float FirstClassPrediction { get; set; }
        public float SecondClassPrediction { get; set; }
        public bool? TiaInTwoWeeksOccured { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
}
