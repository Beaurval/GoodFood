using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_orders.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private const double ServiceChargeCoefficient = 0.05;
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<ICollection<Order>> GetAllOrders() 
            => await _orderContext.Orders.ToListAsync();

        public async Task<Order> GetOrderById(int id) => (await _orderContext.Orders.FirstOrDefaultAsync(o => o.Id == id))!;

        public async Task<Order> CreateOrder(CreateOrderModel orderModel)
        {
            var order = new Order
            {
                Tip = orderModel.Tip,
                ShippingCharge = 2.5,
            };

            order.TotalPrice = order.ShippingCharge; //TODO : calculate the price of the order
            order.ServiceCharge = order.TotalPrice * ServiceChargeCoefficient;
            order.TotalPrice += order.ServiceCharge + order.Tip;

            await _orderContext.Orders.AddAsync(order);

            return order;
        }

        public async Task UpdateOrder(UpdateOrderModel orderModel)
        {
            Order orderFromDatabase = await GetOrderById(orderModel.Id);
            orderFromDatabase.ServiceCharge = orderModel.ServiceCharge;
            orderFromDatabase.ShippingCharge = orderModel.ShippingCharge;
            orderFromDatabase.Tip = orderModel.Tip;
            
            orderFromDatabase.TotalPrice = orderFromDatabase.ServiceCharge + orderFromDatabase.ShippingCharge; //TODO : calculate the price of the order

            _orderContext.Orders.Update(orderFromDatabase);
        }

        public async void DeleteOrder(int id) 
            => _orderContext.Orders.Remove(await GetOrderById(id));
    }
}
