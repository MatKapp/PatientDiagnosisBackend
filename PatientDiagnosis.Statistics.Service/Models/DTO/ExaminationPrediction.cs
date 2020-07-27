using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Examinations.Service.Models.DTO
{
    public class ExaminationPrediction
    {
        public long Id { get; set; }
        public float FirstClassPrediction { get; set; }
        public float SecondClassPrediction { get; set; }
    }
}
