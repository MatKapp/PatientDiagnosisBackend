using PatientDiagnosis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Services.Interfaces
{
    public interface IPatientService
    {
        void Add(Patient patient);
        Task<Patient[]> GetAllAsync();
    }
}
