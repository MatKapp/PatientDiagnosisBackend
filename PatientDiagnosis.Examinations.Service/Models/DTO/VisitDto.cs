using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Examinations.Service.Models.DTO
{
    public class VisitDto
    {
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public long ExaminationId { get; set; }
        public bool IsFinished { get; set; }
    }
}
