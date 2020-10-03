using System.Collections.Generic;
using System.Threading.Tasks;
using PatientDiagnosis.Common.Models.Entities;
using PatientDiagnosis.Statistics.Service.Models.DTO;

namespace PatientDiagnosis.Examinations.Service.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<RoundedPredictionFrequency>> GetPredictionFrequencyStatistics();

        Task<IEnumerable<AggregatedAgeFrequency>> GetAgeFrequencyStatistics(int interval);

        Task<IEnumerable<TiaOccuredFrequency>> GetTiaOccuredFrequencyStatistics();

        Task<IEnumerable<ObservationOccurenceRatio>> GetObservationsRatioByTiaOccured(bool tiaOccured);

        Task<Examination[]> GetAllExaminationsAsync();
    }
}
