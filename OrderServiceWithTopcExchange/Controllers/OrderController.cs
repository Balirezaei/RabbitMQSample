using CommonRabbitMQTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OrderServiceWithTopcExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPublisher _publisher;

        public OrderController(IPublisher publisher)
        {
            this._publisher = publisher;
        }
        [HttpPost]
        public async Task PublishOrderToQueue([FromBody]OrderModel order)
        {
            _publisher.Publish(JsonConvert.SerializeObject(order), "order.created", null);
        }

      
    }
}
