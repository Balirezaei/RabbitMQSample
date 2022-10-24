using CommonRabbitMQTools;
using Newtonsoft.Json;

namespace CustomerOrderReportServiceWithTopicExchange
{
    public class ServiceHostSubcriber : IHostedService
    {
        private const int DEFAULT_QUANTITY = 100;
        private readonly ISubscriber subscriber;
        private readonly IInMemoryDb _db;

        public ServiceHostSubcriber(ISubscriber subscriber, IInMemoryDb db)
        {
            this.subscriber = subscriber;
            _db = db;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            subscriber.Subscribe(ProcessMessage);
            return Task.CompletedTask;
        }

        private bool ProcessMessage(string message, IDictionary<string, object> headers)
        {
            var order = JsonConvert.DeserializeObject<OrderModel>(message);
            _db.AddToOrders(order);
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
