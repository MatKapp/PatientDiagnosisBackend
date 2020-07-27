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
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationRepository examinationRepository;
        private readonly IRabbitMqSendingService rabbitMqSendingMessageService;

        public ExaminationsController(IExaminationRepository examinationRepository
                                ,IRabbitMqSendingService rabbitMqSendingMessageService)
        {
            this.examinationRepository = examinationRepository;
            this.rabbitMqSendingMessageService = rabbitMqSendingMessageService;
        }

        [HttpGet]
        [Route("/api/[controller]/{id?}")]
        public async Task<IActionResult> Get(long? id)
        {
            if (id is null)
            {
                var examinations = await examinationRepository.GetAllAsync();
                return Ok(examinations);
            }

            var examination = await examinationRepository.GetAsync(id.Value);

            if (examination is null)
                return NotFound();

            return Ok(examination);
        }

        [HttpGet]
        [Route("/api/[controller]/GetByPatient/{id}")]
        public async Task<IActionResult> GetByPatient(long id)
        {
            var patientExamination = await examinationRepository.GetByPatientAsync(id);

            if (patientExamination is null)
                return NotFound();

            return Ok(patientExamination);
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public async Task<IActionResult> Post(Examination examination)
        {
            await examinationRepository.AddAsync(examination);

            rabbitMqSendingMessageService.SendMessage(JsonSerializer.Serialize(examination), RabbitExchangeMapping.Examination);
            return Ok();
        }

        [HttpDelete]
        [Route("/api/[controller]/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var examination = await examinationRepository.GetAsync(id);

            if (examination is null)
                return NotFound();

            await examinationRepository.DeleteAsync(examination);

            return Ok();
        }

        [HttpPut]
        [Route("/api/[controller]/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Examination examination)
        {
            await examinationRepository.UpdateExaminationAsync(id, examination);

            examination.Id = id;
            rabbitMqSendingMessageService.SendMessage(JsonSerializer.Serialize(examination), RabbitExchangeMapping.Examination);


            return Ok();
        }
    }
}
