using PatientDiagnosis.Common.Services.Interfaces;

namespace PatientDiagnosis.Patients.Service.Services
{
    public class RabbitMQHandler : IRabbitMQHandler
    {
        public void HandleMessage(string message)
        {
            System.Console.WriteLine(message);   
        }
    }
}
