namespace PatientDiagnosis.Common.Architecture.Interfaces
{
    public interface IRabbitMQHandler
    {
        void  HandleMessage(string message, string routingKey);
    }
}
