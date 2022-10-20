using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_orders.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<ICollection<Order>> GetAllOrders() 
            => await _orderContext.Orders.Include("Lines").ToListAsync();

        public async Task<Order> GetOrderById(int id) => (await _orderContext.Orders.Include("Lines").FirstOrDefaultAsync(o => o.Id == id))!;

        public async Task<Order> CreateOrder(CreateOrderModel orderModel)
        {
            var order = new Order
            {
                Lines = new List<OrderLine>(),
                RestaurantId = orderModel.RestaurantId,
                UserId = orderModel.OrderId
            };

            await _orderContext.Orders.AddAsync(order);

            return order;
        }

        public async Task UpdateOrder(UpdateOrderModel orderModel)
        {
            Order orderFromDatabase = await GetOrderById(orderModel.Id);
            orderFromDatabase.Tip = orderModel.Tip;
            orderFromDatabase.RestaurantId = orderModel.RestaurantId;

            _orderContext.Orders.Update(orderFromDatabase);
        }

        public async Task DeleteOrder(int id) 
            => _orderContext.Orders.Remove(await GetOrderById(id));
    }
}
