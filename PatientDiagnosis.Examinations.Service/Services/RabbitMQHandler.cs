using System.Text.Json;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Services
{
    public class RabbitMQHandler : IRabbitMQHandler
    {
        private readonly IExaminationRepository examinationRepository;

        public RabbitMQHandler(IExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }

        public async void HandleMessage(string message, string routingKey)
        {
            var prediction = JsonSerializer.Deserialize<ExaminationPrediction>(message);
            await examinationRepository.UpdateExaminationPredictionsAsync(prediction);
        }
    }
}
