namespace PatientDiagnosis.Common.Architecture.Interfaces
{
    public interface IRabbitMqSendingService
    {
        void SendMessage(string message);
    }
}
