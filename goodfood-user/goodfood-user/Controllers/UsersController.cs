using System.Net;
using goodfood_user.Exeptions;
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

        //Roles
        [Route("{idUser}/roles/{idRole}")]
        [HttpPut]
        public async Task<ActionResult> ChangeUserRole(int idRole, int idUser)
        {
            await _userService.ChangeUserRoleAsync(idRole, idUser);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        //Users
        [HttpGet("{idUser}")]
        public async Task<ActionResult<GetUserModel>> GetUserById(int idUser)
        {
            if (!(await _userService.UserExist(idUser)))
                return NotFound();

            return await _userService.GetUserAsync(idUser);
        }
        [Route("exist")]
        [HttpGet]
        public async Task<ActionResult<bool>> UserExistWithMail(string email)
        {
            return await _userService.UserExistWithMail(email);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetUserModel>>> GetAllUsers()
        {
            return (await _userService.GetAllUsersAsync()).ToList();
        }
        [Route("identifier")]
        [HttpGet]
        public async Task<ActionResult<GetUserModel>> GetUsersByUuid(string uuid)
        {
            return Ok(await _userService.GetUserWithUuid(uuid));
        }

        [HttpPost]
        public async Task<ActionResult<GetUserModel>> CreateUser(CreateUserModel userModel)
        {
            var result = new GetUserModel();

            try
            {
                result = await _userService.CreateUserAsync(userModel);
            }
            catch (PasswordDoesNotMatchException e)
            {
                Response.StatusCode = 400;
                return Content("Passwords does not match.");
            }

            await _unitOfWork.SaveChangesAsync();

            return result;
        }
        [Route("roles")]
        [HttpPost]
        public async Task<ActionResult<GetUserWithRoleModel>> CreateUserWithRole(CreateUserWithRoleModel userModel)
        {
            var result = await _userService.CreateUserWithRoleAsync(userModel);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        [Route("{idUser}/reset")]
        [HttpPut]
        public async Task<ActionResult> ResetPassword(int idUser, string password, string confirmPassword)
        {
            if (!await _userService.ResetPassword(idUser, password, confirmPassword))
            {
                return BadRequest();
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{idUser}")]
        public async Task<ActionResult<UpdateUserModel>> UpdateUser(UpdateUserModel userModel, int idUser)
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
        [Route("{idUser}/confirm")]
        [HttpPut]
        public async Task<ActionResult> ConfirmUserRegistration(int idUser)
        {
            if (!(await _userService.UserExist(idUser)))
                return NotFound();

            await _userService.ConfirmRegistration(idUser);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
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
