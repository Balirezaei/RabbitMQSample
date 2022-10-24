using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

using var connection = factory.CreateConnection();
using var chanel = connection.CreateModel();
DirectExchangePublisher.Publish(chanel);
Console.WriteLine("Press Enter to exit");
Console.ReadLine();
