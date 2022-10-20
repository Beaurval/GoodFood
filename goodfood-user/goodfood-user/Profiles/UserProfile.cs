using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Models.User;

namespace goodfood_user.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<GetUserModel, User>();
            CreateMap<User, GetUserModel>();
            CreateMap<User, GetUserWithRoleModel>();
            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<CreateUserWithRoleModel, User>();
        }

    }
}
