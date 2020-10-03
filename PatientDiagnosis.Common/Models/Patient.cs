using System;

namespace PatientDiagnosis.Patients.Service.Models
{
    public class Patient
    {
        public long? Id { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
