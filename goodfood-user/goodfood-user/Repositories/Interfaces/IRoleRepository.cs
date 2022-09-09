using goodfood_user.Entities;
using goodfood_user.Models.Role;

namespace goodfood_user.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> GetRole(int idRole);
        public Task<ICollection<Role>> GetAllRoles();
        public Task<Role> CreateRole(Role role);
        public void UpdateRole(Role role);
        public void DeleteRole(Role role);
    }
}
