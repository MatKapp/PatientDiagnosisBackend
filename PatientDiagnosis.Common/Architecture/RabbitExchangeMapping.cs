using System;
using System.Collections.Generic;
using System.Text;

namespace PatientDiagnosis.Common.Architecture
{
    public static class RabbitExchangeMapping
    {
        public static string Examination = "examination";
        public static string ExaminationResult = "examination.prediction";
    }
}
