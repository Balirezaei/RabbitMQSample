using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
DirectExchangeConsumer.Consume(channel);
Console.WriteLine("Press Enter to exit");
Thread.Sleep(100000);
Console.ReadLine();