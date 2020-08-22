using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Statistics.Service.Models.DTO
{
    public class AggregatedAgeFrequency
    {
        public int DownAgeBoundary { get; set; }
        public int UpAgeBoundary { get; set; }
        public int Frequency { get; set; }
    }
}
