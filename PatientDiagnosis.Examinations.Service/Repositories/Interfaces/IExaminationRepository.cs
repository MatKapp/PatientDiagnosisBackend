using System.Threading.Tasks;
using PatientDiagnosis.Common.Models.Entities;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Models.Entities;

namespace PatientDiagnosis.Examinations.Service.Repositories.Interfaces
{
    public interface IExaminationRepository
    {
        Task<long> AddAsync(Examination examination);

        Task DeleteAsync(Examination examinationId);

        Task<Examination> GetAsync(long id);

        Task<Examination[]> GetAllAsync();

        Task UpdateTiaOccured(long examinationId, bool occurred);

        Task UpdateExaminationPredictionsAsync(ExaminationPrediction prediction);
        Task UpdateExaminationAsync(long id, Examination examination);
        Task<Examination> GetByPatientAsync(long id);
        Task<VisitDto[]> GetPatientVisists(long id);
    }
}
