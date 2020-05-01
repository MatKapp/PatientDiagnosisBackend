using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PatientDiagnosis.Common.Configuration;
using PatientDiagnosis.Common.Services.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PatientDiagnosis.Architecture
{
    public class ConsumeRabbitMqHostedService : BackgroundService
    {
        private IConnection connection;
        private IModel channel;
        private readonly RabbitMQConfiguration configuration;
        private readonly IRabbitMQHandler rabbitMQHandler;

        public ConsumeRabbitMqHostedService(IOptions<RabbitMQConfiguration> configuration,
            IRabbitMQHandler rabbitMQHandler)
        {
            this.configuration = configuration.Value;
            InitRabbitMQ();
            this.rabbitMQHandler = rabbitMQHandler;
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = configuration.Address };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(configuration.Queue, false, false, false, null);
            channel.QueueBind(configuration.Queue, configuration.Exchange, $"{configuration.Queue}.*", null);
            channel.BasicQos(0, 1, false);
            connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                // received message  
                var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());

                // handle the received message  
                HandleMessage(content);
                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(configuration.Queue, false, consumer);
            return Task.CompletedTask;
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HandleMessage(string content)
        {
            rabbitMQHandler.HandleMessage(content);   
        }
    }
}
