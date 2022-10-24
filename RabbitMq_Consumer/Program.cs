// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    var queueName = "learnRabbitOct2022";
    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (ch, ea) =>
    {
        var message = Encoding.UTF8.GetString(ea.Body.Span);
        channel.BasicAck(ea.DeliveryTag, false);
        Console.WriteLine(message);
    };
    String consumerTag = channel.BasicConsume(queueName, false, consumer);
    Console.WriteLine("Press Enter to exit");
    Thread.Sleep(100000);
}

