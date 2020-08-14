using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientDiagnosis.Common.Architecture;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Patients.Service.Models;
using PatientDiagnosis.Patients.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Patients.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;
        private readonly IRabbitMqSendingService rabbitMqSendingMessageService;

        public PatientsController(IPatientRepository patientRepository
                                ,IRabbitMqSendingService rabbitMqSendingMessageService)
        {
            this.patientRepository = patientRepository;
            this.rabbitMqSendingMessageService = rabbitMqSendingMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await patientRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var patient = await patientRepository.GetAsync(id);

            if (patient is null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            await patientRepository.AddAsync(patient);

            rabbitMqSendingMessageService.SendMessage(JsonSerializer.Serialize(patient), RabbitExchangeMapping.Examination);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var patient = await patientRepository.GetAsync(id);

            if (patient is null)
                return NotFound();

            await patientRepository.DeleteAsync(patient);

            return Ok();
        }
    }
}
