using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Common.Configuration;
using PatientDiagnosis.Models;
using PatientDiagnosis.Repositories.Interfaces;
using PatientDiagnosis.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace PatientDiagnosis.Controllers
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

            rabbitMqSendingMessageService.SendMessage("HelloWorlds");
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
