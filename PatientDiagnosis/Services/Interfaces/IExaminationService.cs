using System.Collections.Generic;
using PatientDiagnosis.Common.Models.Entities;

namespace PatientDiagnosis.Patients.Service.Services.Interfaces
{
    public interface IExaminationService
    {
        IList<Examination> GetByPatient(long patientId);
    }
}
