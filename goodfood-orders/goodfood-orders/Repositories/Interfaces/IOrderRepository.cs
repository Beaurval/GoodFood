using goodfood_orders.Entities;
using goodfood_orders.Models;

namespace goodfood_orders.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<ICollection<Order>> GetAllOrders();
        public Task<Order> GetOrderById(int id);
        public Task<ICollection<Order>> GetOrderByIdUser(int idUser);
        public Task<Order> CreateOrder(CreateOrderModel orderModel);
        public Task UpdateOrder(UpdateOrderModel orderModel);
        public Task DeleteOrder(int id);
    }
}
