using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PatientDiagnosis.Common.Architecture;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Common.Models.Entities;
using PatientDiagnosis.Examinations.Service.HubConfig;
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

        [HttpGet]
        [Route("/api/[controller]/GetVisitsByPatient/{id}")]
        public async Task<IActionResult> GetVisitsByPatient(long id)
        {
            var patientVisits = await examinationRepository.GetPatientVisists(id);

            if (patientVisits is null)
                return NotFound();

            return Ok(patientVisits);
        }

        [HttpGet]
        [Route("/api/[controller]")]
        public async Task<IActionResult> Get()
        {
            var examinations = await examinationRepository.GetAllAsync();
            var examinationsPresentation = examinations.Select(examination => new ExaminationPresentation
            {
                AtrialFibrillation = GetPresenceLabel(examination.AtrialFibrillation),
                BodyWeakness = GetPresenceLabel(examination.BodyWeakness),
                FirstClassPrediction = examination.FirstClassPrediction,
                FirstTia = GetPresenceLabel(examination.FirstTia),
                GaitDisturb = GetPresenceLabel(examination.GaitDisturb),
                HighGlucose = GetPresenceLabel(examination.HighGlucose),
                Id = examination.Id,
                Infraction = examination.Infraction.GetValueOrDefault(),
                InitialDbp = examination.InitialDbp.GetValueOrDefault(),
                PatientId = examination.PatientId,
                SecondClassPrediction = examination.SecondClassPrediction,
                SpeechDif = GetPresenceLabel(examination.SpeechDif),
                TiaInTwoWeeksOccured = GetPresenceLabel(examination.TiaInTwoWeeksOccured),
                Vertigo = GetPresenceLabel(examination.Vertigo),
            });
            return Ok(examinationsPresentation);
        }

        private string GetPresenceLabel(bool? boolOrNull)
        {
            if (!boolOrNull.HasValue)
                return "";

            if (boolOrNull.GetValueOrDefault())
            {
                return "present";
            }
            else
            {
                return "absent";
            }
        }

        [HttpGet]
        [Route("/api/[controller]/Entries")]
        public async Task<IActionResult> Entries()
        {
            var examinations = await examinationRepository.GetAllAsync();
            return Ok(examinations);
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public async Task<IActionResult> Post(Examination examination)
        {
            examination.AdmissionDate = DateTime.UtcNow;
            var examinationId = await examinationRepository.AddAsync(examination);

            rabbitMqSendingMessageService.SendMessage(JsonSerializer.Serialize(examination), RabbitExchangeMapping.Examination);
            return Ok(examinationId);
        }

        [HttpPost]
        [Route("/api/[controller]/FinishVisit/{examinationId}")]
        public async Task<IActionResult> FinishVisit(long examinationId)
        {

            var examination = await examinationRepository.GetAsync(examinationId);

            if (examination is null)
                return NotFound();

            examination.DischargeDate = DateTime.UtcNow;
            await examinationRepository.UpdateExaminationAsync(examinationId, examination);
            return Ok();
        }

        [HttpPost]
        [Route("/api/[controller]/ConfirmTiaOccured/{id}")]
        public async Task<IActionResult> ConfirmTiaOccured(long id, [FromBody]bool occurred)
        {
            await examinationRepository.UpdateTiaOccured(id, occurred);
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
