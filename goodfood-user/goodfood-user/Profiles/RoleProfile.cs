using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Models.Role;

namespace goodfood_user.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<GetRoleModel,Role>();
            CreateMap<Role, GetRoleModel>();
            CreateMap<CreateRoleModel, Role>();
            CreateMap<UpdateRoleModel, Role>();
        }
    }
}
