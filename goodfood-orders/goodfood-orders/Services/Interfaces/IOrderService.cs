using goodfood_orders.Entities;
using goodfood_orders.Models;

namespace goodfood_orders.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ICollection<Order>> GetAllOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<ICollection<Order>> GetOrderByIdUserAsync(int id);
        public Task<Order> CreateOrderAsync(CreateOrderModel orderModel);
        public Task UpdateOrderAsync(UpdateOrderModel orderModel);
        public void DeleteOrder(int id);
    }
}
