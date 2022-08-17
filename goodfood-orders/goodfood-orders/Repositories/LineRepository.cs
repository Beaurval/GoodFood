using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_orders.Repositories
{
    public class LineRepository : ILineRepository
    {
        private readonly OrderContext _orderContext;

        public LineRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<OrderLine> GetLine(int idLine) 
            => (await _orderContext.Lines.FirstOrDefaultAsync(l => l.Id == idLine))!;

        public async Task<ICollection<OrderLine>> GetLineForOrderAsync(int idOrder) 
            => await _orderContext.Lines.Where(l => l.OrderId == idOrder).ToListAsync();

        public async Task<OrderLine> AddLine(CreateOrderLineModel lineModel)
        {
            var line = new OrderLine
            {
                ProductId = lineModel.ProductId,
                Quantity = 1,
                OrderId = lineModel.OrderId,
            };
            
            await _orderContext.Lines.AddAsync(line);
            return line;
        }

        public async Task UpdateLine(UpdateOrderLineModel lineModel)
        {
            OrderLine lineFromDatabase = await GetLine(lineModel.Id);
            lineFromDatabase.Quantity = lineModel.Quantity;

            _orderContext.Update(lineFromDatabase);
        }

        public async Task DeleteLine(int idLine) 
            => _orderContext.Lines.Remove(await GetLine(idLine));
    }
}
