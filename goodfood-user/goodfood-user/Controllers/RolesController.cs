using goodfood_user.Models.Role;
using goodfood_user.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IRoleService roleService, IUnitOfWork unitOfWork)
        {
            _roleService = roleService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{idRole}")]
        public async Task<ActionResult<GetRoleModel>> GetRoleById(int idRole)
        {
            return await _roleService.GetRoleAsync(idRole);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetRoleModel>>> GetAllRoles()
        {
            var result = (await _roleService.GetAllRolesAsync()).ToList();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<GetRoleModel>> CreateRole(CreateRoleModel roleModel)
        {
            GetRoleModel role = await _roleService.CreateRoleAsync(roleModel);
            await _unitOfWork.SaveChangesAsync();
            return role;
        }

        [HttpPut("{idRole}")]
        public async Task<ActionResult> UpdateRole(UpdateRoleModel roleModel, int idRole)
        {
            if (!(await _roleService.RoleExist(idRole)))
                return NotFound();
            if (idRole != roleModel.Id)
                return BadRequest();

            _roleService.UpdateRole(roleModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idRole}")]
        public async Task<ActionResult> DeleteRole(int idRole)
        {
            if (!(await _roleService.RoleExist(idRole)))
                return NotFound();

            _roleService.DeleteRole(idRole);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
