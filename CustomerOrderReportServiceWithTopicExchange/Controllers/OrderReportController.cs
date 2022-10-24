using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderReportServiceWithTopicExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReportController : ControllerBase
    {
        private readonly IInMemoryDb _db;

        public OrderReportController(IInMemoryDb db)
        {
            _db = db;
        }

        [HttpGet]
        public List<OrderModel> GetAll()
        {
            return _db.GetOrders();
        }
    }
}
