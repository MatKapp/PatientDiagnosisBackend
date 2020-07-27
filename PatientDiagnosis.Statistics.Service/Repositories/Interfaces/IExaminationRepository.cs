using System.Collections.Generic;
using System.Threading.Tasks;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Statistics.Service.Models.DTO;

namespace PatientDiagnosis.Examinations.Service.Repositories.Interfaces
{
    public interface IExaminationRepository
    {
        Task<Examination> GetAsync(long id);

        Task<Examination[]> GetAllAsync();

        Task<IEnumerable<RoundedPredictionFrequency>> GetPredictionFrequencyStatistics();
    }
}
