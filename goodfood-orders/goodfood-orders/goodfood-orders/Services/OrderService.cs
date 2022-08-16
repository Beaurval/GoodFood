using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Repositories.Interfaces;
using goodfood_orders.Services.Interfaces;

namespace goodfood_orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync() 
            => await _orderRepository.GetAllOrders();

        public async Task<Order> GetOrderByIdAsync(int id) 
            => await _orderRepository.GetOrderById(id);

        public async Task<Order> CreateOrderAsync(CreateOrderModel orderModel) => await _orderRepository.CreateOrder(orderModel);

        public async Task UpdateOrderAsync(UpdateOrderModel orderModel)
        {
            await _orderRepository.UpdateOrder(orderModel);
        }

        public void DeleteOrder(int id)
        {
             _orderRepository.DeleteOrder(id);
        }
    }
}
