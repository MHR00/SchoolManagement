using Producer.WebAPI.Dto;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Producer.WebAPI.Services
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "message", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.WriteLine("--> Connected To MessageBus");


            }
            catch (Exception ex)
            {

                Console.WriteLine($"--> Could not Connect to The Message Bus : {ex.Message}");
            }
        }
        public void PublishMessage(Messages messages)
        {
            var message = JsonSerializer.Serialize(messages);

            if (_connection.IsOpen)
            {
                Console.WriteLine("--> RabbitMQ Connection is Open , Sending Message...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("--> RabbitMQ Connection is Close , Not Sending Message...");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "message",
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine($"--> We Have Send {message}");
        }

        public void Dispose()
        {
            Console.WriteLine("MessageBus Disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> RabbitMQ Connection Shutdown");
        }
    }
}
