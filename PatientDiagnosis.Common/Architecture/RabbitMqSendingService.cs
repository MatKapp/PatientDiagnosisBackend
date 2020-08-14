using System.Text;
using Microsoft.Extensions.Options;
using PatientDiagnosis.Common.Architecture.Interfaces;
using PatientDiagnosis.Common.Configuration;
using RabbitMQ.Client;

namespace PatientDiagnosis.Common.Architecture
{
    class RabbitMqSendingService : IRabbitMqSendingService
    {
        private readonly RabbitMQConfiguration configuration;

        public RabbitMqSendingService(IOptions<RabbitMQConfiguration> configuration)
        {
            this.configuration = configuration.Value;
        }

        public void SendMessage(string message, string binding = "")
        {
            if (string.IsNullOrEmpty(binding))
                binding = configuration.Queue;
            var factory = new ConnectionFactory() { HostName = configuration.Address };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(configuration.Queue, false, false, false, null);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: configuration.Exchange, routingKey: binding, null, body);
        }
    }
}
