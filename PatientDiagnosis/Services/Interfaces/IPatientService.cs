using System.Threading.Tasks;
using PatientDiagnosis.Patients.Service.Models;

namespace PatientDiagnosis.Patients.Service.Services.Interfaces
{
    public interface IPatientService
    {
        void Add(Patient patient);
        Task<Patient[]> GetAllAsync();
    }
}
