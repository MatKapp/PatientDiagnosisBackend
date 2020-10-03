using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientDiagnosis.Common.Models.Entities;
using PatientDiagnosis.Patients.Service.Services.Interfaces;

namespace PatientDiagnosis.Patients.Service.Services
{
    public class ExaminationService : IExaminationService
    {
        public IList<Examination> GetByPatient(long patientId)
        {
            throw new NotImplementedException();
        }
    }
}
