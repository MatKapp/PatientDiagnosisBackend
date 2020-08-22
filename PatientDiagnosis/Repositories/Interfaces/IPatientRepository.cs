using System.Threading.Tasks;
using PatientDiagnosis.Patients.Service.Models;

namespace PatientDiagnosis.Patients.Service.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);

        Task DeleteAsync(Patient patientId);

        Task<Patient> GetAsync(long id);

        Task<Patient[]> GetAllAsync();
        Task UpdatePatientAsync(long id, Patient patient);
    }
}
