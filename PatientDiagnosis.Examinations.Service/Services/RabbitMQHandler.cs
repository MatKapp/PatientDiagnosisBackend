using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Examinations.Service.HubConfig;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Services
{
    public class RabbitMQHandler : IRabbitMQHandler
    {
        private readonly IExaminationRepository examinationRepository;
        private readonly IHubContext<ExaminationPredictionHub> predictionHub;

        public RabbitMQHandler(IExaminationRepository examinationRepository,
                            IHubContext<ExaminationPredictionHub> predictionHub)
        {
            this.examinationRepository = examinationRepository;
            this.predictionHub = predictionHub;
        }

        public async Task HandleMessageAsync(string message, string routingKey)
        {
            var prediction = JsonSerializer.Deserialize<ExaminationPrediction>(message);
            await examinationRepository.UpdateExaminationPredictionsAsync(prediction);
            await predictionHub.Clients.All.SendAsync("prediction", message);
        }
    }
}
