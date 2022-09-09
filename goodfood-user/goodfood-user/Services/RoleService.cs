using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Models.Role;
using goodfood_user.Repositories.Interfaces;
using goodfood_user.Services.Interfaces;

namespace goodfood_user.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<GetRoleModel> GetRoleAsync(int idRole) 
            => _mapper.Map<GetRoleModel>(await _roleRepository.GetRole(idRole));

        public async Task<ICollection<GetRoleModel>> GetAllRolesAsync() 
            => _mapper.Map<ICollection<GetRoleModel>>(await _roleRepository.GetAllRoles());

        public async Task<GetRoleModel> CreateRoleAsync(CreateRoleModel roleModel)
        {
            Role role = await _roleRepository.CreateRole(_mapper.Map<Role>(roleModel));

            return _mapper.Map<GetRoleModel>(role);
        }

        public void UpdateRole(UpdateRoleModel roleModel)
        {
            _roleRepository.UpdateRole(_mapper.Map<Role>(roleModel));
        }

        public async void DeleteRole(int idRole)
        {
            _roleRepository.DeleteRole(_mapper.Map<Role>(await _roleRepository.GetRole(idRole)));
        }

        public async Task<bool> RoleExist(int idRole)
        {
            return await _roleRepository.GetRole(idRole) != null;
        }
    }
}
