using RabbitMQ.Client;
using System.Text;

public static class DirectExchangePublisher
{
    public static void Publish(IModel channel) {

        channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);

        for (int i = 0; i < 5; i++)
        {
            string message = $"This is a message.{DateTime.Now.ToString("D")} - {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "demo-direct-exchange",
                routingKey: "account.init", basicProperties: null, body: body);

            Console.WriteLine("Sent {0}", message);
            Thread.Sleep(5000);
        }
    }
}