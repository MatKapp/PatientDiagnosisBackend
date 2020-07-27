using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Statistics.Service.Models.DTO
{
    public class RoundedPredictionFrequency
    {
        public double RoandedPrediction { get; set; }
        public int Frequency { get; set; }
    }
}
