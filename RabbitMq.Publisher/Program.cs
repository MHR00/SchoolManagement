using RabbitMq.Publisher;
using RabbitMQ.Client;

static class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        DirectExchangePublisher.Publish(channel);
    }
}