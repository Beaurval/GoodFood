using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Repositories.Interfaces;
using goodfood_orders.Services.Interfaces;

namespace goodfood_orders.Services
{
    public class LineService : ILineService
    {
        private readonly ILineRepository _lineRepository;

        public LineService(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public async Task<OrderLine> GetLine(int idLine) 
            => await _lineRepository.GetLine(idLine);

        public async Task<ICollection<OrderLine>> GetLinesFromOrder(int idOrder) 
            => await _lineRepository.GetLineForOrderAsync(idOrder);

        public async Task<OrderLine> AddLine(CreateOrderLineModel lineModel) 
            => await _lineRepository.AddLine(lineModel);

        public async Task UpdateLine(UpdateOrderLineModel lineModel)
        {
            if (lineModel.Quantity > 0)
            {
                await _lineRepository.UpdateLine(lineModel);
            }
            else
            {
                await _lineRepository.DeleteLine(lineModel.Id);
            }
        }

        public async Task DeleteLine(int idLine) 
            => await _lineRepository.DeleteLine(idLine);
    }
}
