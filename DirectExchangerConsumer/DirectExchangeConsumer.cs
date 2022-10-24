using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public static class DirectExchangeConsumer
{
    public static void Consume(IModel channel)
    {
        var queueName = "demo-direct-queue";
        channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        //Bind queue to Exchange
        channel.QueueBind(queueName, "demo-direct-exchange", "account.init");

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (ch, ea) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(ea.Body.Span);
            channel.BasicAck(ea.DeliveryTag, false);
            Console.WriteLine(message);
        };
        String consumerTag = channel.BasicConsume(queueName, false, consumer);
    }
}