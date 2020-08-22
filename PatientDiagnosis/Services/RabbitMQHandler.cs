using System.Threading.Tasks;
using PatientDiagnosis.Common.Architecture.Interfaces;

namespace PatientDiagnosis.Patients.Service.Services
{
    public class RabbitMQHandler : IRabbitMQHandler
    {
        public Task HandleMessageAsync(string message, string routingKey)
        {
            return Task.CompletedTask;
        }
    }
}
