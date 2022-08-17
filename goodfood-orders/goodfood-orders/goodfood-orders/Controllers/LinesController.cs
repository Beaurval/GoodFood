using goodfood_orders.Entities;
using goodfood_orders.Models;
using goodfood_orders.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILineService _lineService;

        public LinesController(IUnitOfWork unitOfWork, ILineService lineService)
        {
            _unitOfWork = unitOfWork;
            _lineService = lineService;
        }

        [HttpGet("{idOrder}")]
        public async Task<ActionResult<ICollection<OrderLine>>> GetLinesFromOrder(int idOrder) 
            => (await _lineService.GetLinesFromOrder(idOrder)).ToList();

        [HttpPost("{idOrder}")]
        public async Task<ActionResult<OrderLine>> AddLineToOrder(int idOrder, [FromForm] CreateOrderLineModel orderLineModel)
        {
            if (idOrder != orderLineModel.OrderId)
                return NotFound();

            OrderLine orderLine = await _lineService.AddLine(orderLineModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok(orderLine);
        }

        [HttpPut("{idLine}")]
        public async Task<ActionResult> UpdateLine(int idLine, [FromForm] UpdateOrderLineModel orderLineModel)
        {
            if(idLine != orderLineModel.Id)
                return NotFound();

            await _lineService.UpdateLine(orderLineModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idLine}")]
        public async Task<ActionResult> DeleteLine(int idLine)
        {
            await _lineService.DeleteLine(idLine);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
