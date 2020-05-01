using PatientDiagnosis.Models;
using System.Threading.Tasks;

namespace PatientDiagnosis.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);

        Task DeleteAsync(Patient patientId);

        Task<Patient> GetAsync(long id);

        Task<Patient[]> GetAllAsync();

    }
}
