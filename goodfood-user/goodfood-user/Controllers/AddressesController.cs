using goodfood_user.Models.Address;
using goodfood_user.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IUnitOfWork _unitOfWork;

        public AddressesController(IAddressService addressService, IUnitOfWork unitOfWork)
        {
            _addressService = addressService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{idAddress}")]
        public async Task<ActionResult<GetAddressModel>> GetAddress(int idAddress)
        {
            return await _addressService.GetAddressAsync(idAddress);
        }

        [HttpPut("{idAddress}")]
        public async Task<ActionResult> UpdateAddress([FromForm] UpdateAddressModel addressModel, int idAddress)
        {
            if (addressModel.Id != idAddress)
                return BadRequest();

            if (!(await _addressService.AddressExist(idAddress)))
                return NotFound();

            _addressService.UpdateAddress(addressModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idAddress}")]
        public async Task<ActionResult> DeleteAddress(int idAddress)
        {
            if (!(await _addressService.AddressExist(idAddress)))
                return NotFound();

            await _addressService.DeleteUserAddress(idAddress);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
