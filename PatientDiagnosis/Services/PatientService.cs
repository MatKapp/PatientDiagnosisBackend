using PatientDiagnosis.Models;
using PatientDiagnosis.Repositories.Interfaces;
using PatientDiagnosis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDiagnosis.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;

        public PatientService( IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public void Add(Patient patient)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient[]> GetAllAsync()
            => await patientRepository.GetAllAsync();
    }
}
