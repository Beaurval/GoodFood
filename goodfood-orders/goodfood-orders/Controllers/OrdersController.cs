using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Services.Interfaces;
using Microsoft.Net.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IOrderService orderService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Order>>> GetOrders() 
            => (await _orderService.GetAllOrdersAsync()).ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            Order order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromForm] CreateOrderModel orderModel)
        {
            Order order = await _orderService.CreateOrderAsync(orderModel);
            await _unitOfWork.SaveChangesAsync();

            return order;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromForm] UpdateOrderModel orderModel)
        {
            if (id != orderModel.Id)
                return NotFound();

            await _orderService.UpdateOrderAsync(orderModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
