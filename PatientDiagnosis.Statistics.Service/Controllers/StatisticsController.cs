using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientDiagnosis.Examinations.Service.Services.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IExaminationService examinationsService;

        public StatisticsController(IExaminationService examinationsService)
        {
            this.examinationsService = examinationsService;
        }

        [HttpGet]
        [Route("/api/[controller]/GetPredictionsFrequency/")]
        public async Task<IActionResult> GetPredictionsFrequency()
        {
            var predictionFrequencies = await examinationsService.GetPredictionFrequencyStatistics();

            return Ok(predictionFrequencies);
        }
    }
}
