using goodfood_user.Models.Address;
using goodfood_user.Models.User;
using goodfood_user.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUserService userService, IUnitOfWork unitOfWork, IAddressService addressService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _addressService = addressService;
        }

        //Addresses
        [Route("{idUser}/addresses")]
        [HttpGet]
        public async Task<ActionResult<ICollection<GetAddressModel>>> GetAddressesFromUser(int idUser)
        {
            return (await _addressService.GetAddressesFromUserAsync(idUser)).ToList();
        }
        [Route("{idUser}/addresses")]
        [HttpPost]
        public async Task<ActionResult<GetAddressModel>> AddAddressToUser([FromForm] CreateAddressModel addressModel, int idUser)
        {
            var address = await _addressService.AddAddressToUserAsync(addressModel, idUser);
            await _unitOfWork.SaveChangesAsync();
            return address;
        }

        //Users
        [HttpGet("{idUser}")]
        public async Task <ActionResult<GetUserModel>> GetUser(int idUser)
        {
            return await _userService.GetUserAsync(idUser);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetUserModel>>> GetAllUsers(int idUser)
        {
            return (await _userService.GetAllUsersAsync()).ToList();
        }

        [HttpPost]
        public async Task<GetUserModel> CreateUser([FromForm] CreateUserModel userModel)
        {
            GetUserModel result = await _userService.CreateUserAsync(userModel);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        [HttpPut("{idUser}")]
        public async Task<ActionResult<UpdateUserModel>> UpdateUser([FromForm] UpdateUserModel userModel, int idUser)
        {
            if (userModel.Id != idUser)
            {
                return BadRequest();
            }

            if (!(await _userService.UserExist(idUser)))
                return NotFound();

            GetUserModel result = await _userService.UpdateUserAsync(userModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok(result);
        }

        [HttpDelete("{idUser}")]
        public async Task<ActionResult> DeleteUser(int idUser)
        {
            if (!(await _userService.UserExist(idUser)))
                return NotFound();

            await _userService.DeleteUser(idUser);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

    }
}
