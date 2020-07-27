using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientDiagnosis.Common.Architecture;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Examinations.Service.Models;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IExaminationRepository examinationRepository;

        public StatisticsController(IExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }

        [HttpGet]
        [Route("/api/[controller]/GetPredictionsFrequency/")]
        public async Task<IActionResult> GetPredictionsFrequency()
        {
            var predictionFrequencies = await examinationRepository.GetPredictionFrequencyStatistics();

            return Ok(predictionFrequencies);
        }
    }
}
