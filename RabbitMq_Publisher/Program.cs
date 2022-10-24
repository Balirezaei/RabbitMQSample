// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

using (var connection = factory.CreateConnection())
using (var chanel = connection.CreateModel())
{
    chanel.QueueDeclare(queue: "learnRabbitOct2022", durable: false, exclusive: false, autoDelete: false, arguments: null);

    for (int i = 0; i < 5; i++)
    {
        string message = $"This is a message.{DateTime.Now.ToString("D")} - {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";

        var body = Encoding.UTF8.GetBytes(message);
        chanel.BasicPublish(exchange: "", routingKey: "learnRabbitOct2022", basicProperties: null, body: body);

        Console.WriteLine("Sent {0}", message);
        Thread.Sleep(12000);
    }
   

}

Console.WriteLine("Press Enter to exit");
Console.ReadLine();