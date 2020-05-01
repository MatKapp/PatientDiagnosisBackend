using PatientDiagnosis.Examinations.Service.Models;
using System.Threading.Tasks;

namespace PatientDiagnosis.Repositories.Interfaces
{
    public interface IExaminationRepository
    {
        Task AddAsync(Examination examination);

        Task DeleteAsync(Examination examinationId);

        Task<Examination> GetAsync(long id);

        Task<Examination[]> GetAllAsync();
    }
}
