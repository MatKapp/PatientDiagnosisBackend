using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Statistics.Service.Models.DTO
{
    public class ObservationOccurenceRatio
    {
        public string ObservationName { get; set; }
        public float Ratio { get; set; }
    }
}
