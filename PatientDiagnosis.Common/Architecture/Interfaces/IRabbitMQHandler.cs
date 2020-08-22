using System.Threading.Tasks;

namespace PatientDiagnosis.Common.Architecture.Interfaces
{
    public interface IRabbitMQHandler
    {
        Task HandleMessageAsync(string message, string routingKey);
    }
}
