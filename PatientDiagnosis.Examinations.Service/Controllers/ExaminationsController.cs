using Microsoft.AspNetCore.Mvc;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Examinations.Service.Models;
using PatientDiagnosis.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PatientDiagnosis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
            => Ok(await examinationRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var examination = await examinationRepository.GetAsync(id);

            if (examination is null)
                return NotFound();

            return Ok(examination);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Examination examination)
        {
            await examinationRepository.AddAsync(examination);

            rabbitMqSendingMessageService.SendMessage("HelloWorlds");
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var examination = await examinationRepository.GetAsync(id);

            if (examination is null)
                return NotFound();

            await examinationRepository.DeleteAsync(examination);

            return Ok();
        }
    }
}
