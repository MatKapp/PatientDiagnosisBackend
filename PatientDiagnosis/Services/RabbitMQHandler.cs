using PatientDiagnosis.Common.Architecture.Interfaces;

namespace PatientDiagnosis.Patients.Service.Services
{
    public class RabbitMQHandler : IRabbitMQHandler
    {
        public void HandleMessage(string message, string routingKey)
        {
            System.Console.WriteLine(message);   
        }
    }
}
