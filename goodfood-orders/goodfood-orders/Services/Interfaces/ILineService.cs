using goodfood_orders.Entities;
using goodfood_orders.Models;

namespace goodfood_orders.Services.Interfaces
{
    public interface ILineService
    {
        public Task<OrderLine> GetLine(int idLine);
        public Task<ICollection<OrderLine>> GetLinesFromOrder(int idOrder);
        public Task<OrderLine> AddLine(CreateOrderLineModel lineModel);
        public Task UpdateLine(UpdateOrderLineModel lineModel);
        public Task DeleteLine(int idLine);
    }
}
