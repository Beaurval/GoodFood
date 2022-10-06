using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Repositories.Interfaces;
using goodfood_orders.Services.Interfaces;

namespace goodfood_orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILineRepository _lineRepository;

        public OrderService(IOrderRepository orderRepository, ILineRepository lineRepository)
        {
            _orderRepository = orderRepository;
            _lineRepository = lineRepository;
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync() 
            => await _orderRepository.GetAllOrders();

        public async Task<Order> GetOrderByIdAsync(int id) 
            => await _orderRepository.GetOrderById(id);

        public async Task<Order> CreateOrderAsync(CreateOrderModel orderModel) => await _orderRepository.CreateOrder(orderModel);

        public async Task UpdateOrderAsync(UpdateOrderModel orderModel)
        {
            Order orderFromDb = await _orderRepository.GetOrderById(orderModel.Id);
            if (orderFromDb.RestaurantId != orderModel.RestaurantId)
            {
                foreach (var line in orderFromDb.Lines)
                {
                    await _lineRepository.DeleteLine(line.Id);
                }
            }
            await _orderRepository.UpdateOrder(orderModel);
        }

        public void DeleteOrder(int id)
        {
             _orderRepository.DeleteOrder(id);
        }
    }
}
