using goodfood_orders.Entities;
using goodfood_orders.Models;

namespace goodfood_orders.Repositories.Interfaces
{
    public interface ILineRepository
    {
        public Task<OrderLine> GetLine(int idLine);
        public Task<ICollection<OrderLine>> GetLineForOrderAsync(int idOrder);
        public Task<OrderLine> AddLine(CreateOrderLineModel lineModel);
        public Task UpdateLine(UpdateOrderLineModel lineModel);
        public Task DeleteLine(int idLine);

    }
}
