using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Models;
using goodfood_user.Repositories.Interfaces;
using goodfood_user.Services.Interfaces;

namespace goodfood_user.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapperGet;
        private readonly IMapper _mapperCreate;
        private readonly IMapper _mapperUpdate;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            //Auto mapper
            var configGet = new MapperConfiguration(cfg => cfg.CreateMap<User, GetUserModel>());
            var configCreate = new MapperConfiguration(cfg => cfg.CreateMap<CreateUserModel, User>());
            var configUpdate = new MapperConfiguration(cfg => cfg.CreateMap<UpdateUserModel, User>());

            _mapperGet = configGet.CreateMapper();
            _mapperCreate = configCreate.CreateMapper();
            _mapperUpdate = configUpdate.CreateMapper();
        }

        public async Task<GetUserModel> GetUserAsync(int idUser)
        {
            GetUserModel userModel = _mapperGet.Map<GetUserModel>((await _userRepository.GetUser(idUser)));
            return userModel;
        }

        public async Task<ICollection<GetUserModel>> GetAllUsersAsync()
        {
            List<GetUserModel> usersModel = _mapperGet.Map<List<GetUserModel>>((await _userRepository.GetAllUsers()));
            return usersModel;
        }

        public async Task<GetUserModel> CreateUserAsync(CreateUserModel userModel)
        {
            User user = _mapperCreate.Map<User>(userModel);
            return _mapperGet.Map<GetUserModel>(await _userRepository.CreateUser(user));
        }

        public async Task<GetUserModel> UpdateUserAsync(UpdateUserModel userModel)
        {
            User user = _mapperUpdate.Map<User>(userModel);
            _userRepository.UpdateUser(user);
            return _mapperGet.Map<GetUserModel>(user);
        }

        public async Task DeleteUser(int idUser)
        {
            _userRepository.DeleteUser(await _userRepository.GetUser(idUser));
        }

        public async Task<bool> UserExist(int id)
        {
            User user = await _userRepository.GetUser(id);
            return user != null;
        }
    }
}
