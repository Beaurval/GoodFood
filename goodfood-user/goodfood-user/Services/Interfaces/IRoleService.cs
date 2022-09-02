using goodfood_user.Entities;
using goodfood_user.Models.Role;

namespace goodfood_user.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<GetRoleModel> GetRoleAsync(int idRole);
        public Task<ICollection<GetRoleModel>> GetAllRolesAsync();
        public Task<GetRoleModel> CreateRoleAsync(CreateRoleModel roleModel);
        public void UpdateRole(UpdateRoleModel roleModel);
        public void DeleteRole(int idRole);
        public Task<bool> RoleExist(int idRole);
    }
}
