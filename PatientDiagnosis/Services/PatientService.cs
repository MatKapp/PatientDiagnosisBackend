using System;
using System.Threading.Tasks;
using PatientDiagnosis.Patients.Service.Models;
using PatientDiagnosis.Patients.Service.Repositories.Interfaces;
using PatientDiagnosis.Patients.Service.Services.Interfaces;

namespace PatientDiagnosis.Patients.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
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
