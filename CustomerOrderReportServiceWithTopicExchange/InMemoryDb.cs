
namespace CustomerOrderReportServiceWithTopicExchange
{
    public interface IInMemoryDb
    {
        void AddToOrders(OrderModel order);
        List<OrderModel> GetOrders();
    }

    public class InMemoryDb : IInMemoryDb
    {
        public List<OrderModel> Orders { get; set; }=new List<OrderModel> {  };
        public void AddToOrders(OrderModel order) {

            Orders.Add(order);

        }

        public List<OrderModel> GetOrders()
        {
            return Orders;
        }
    }


    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
