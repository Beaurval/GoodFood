using goodfood_user.Entities;
using goodfood_user.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_user.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserContext _userContext;

        public RoleRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<Role> GetRole(int idRole)
        {
            return (await _userContext.Roles.FirstOrDefaultAsync(r => r.Id == idRole))!;
        }

        public async Task<ICollection<Role>> GetAllRoles()
        {
            return await _userContext.Roles.ToListAsync();
        }

        public async Task<Role> CreateRole(Role role)
        {
            await _userContext.Roles.AddAsync(role);
            return role;
        }

        public void UpdateRole(Role role)
        {
            _userContext.Set<Role>().Update(role);
        }

        public void DeleteRole(Role role)
        {
            _userContext.Roles.Remove(role);
        }
    }
}
