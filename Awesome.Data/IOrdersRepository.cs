using System.Collections.Generic;

namespace Awesome.Data
{
    public interface IOrdersRepository
    {
        void AddOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        Order GetOneOrder(int id);
        (int productCount, decimal ordersTotal) GetOrdersAggregate();
    }
}