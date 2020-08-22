using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientDiagnosis.Examinations.Service.Services.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService examinationsService)
        {
            this.statisticsService = examinationsService;
        }

        [HttpGet]
        [Route("/api/[controller]/GetPredictionsFrequency/")]
        public async Task<IActionResult> GetPredictionsFrequency()
        {
            var predictionFrequencies = await statisticsService.GetPredictionFrequencyStatistics();

            return Ok(predictionFrequencies);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAgeFrequency/")]
        public async Task<IActionResult> GetAgeFrequency()
        {
            var predictionFrequencies = await statisticsService.GetAgeFrequencyStatistics(10);

            return Ok(predictionFrequencies);
        }
    }
}
