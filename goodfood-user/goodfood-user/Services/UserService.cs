using System.Text;
using AutoMapper;
using goodfood_user.Entities;
using goodfood_user.Exeptions;
using goodfood_user.Models.Role;
using goodfood_user.Models.User;
using goodfood_user.Repositories.Interfaces;
using goodfood_user.Services.Interfaces;

namespace goodfood_user.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserModel> GetUserAsync(int idUser)
        {
            GetUserModel userModel = _mapper.Map<GetUserModel>((await _userRepository.GetUser(idUser)));
            return userModel;
        }

        public async Task<ICollection<GetUserModel>> GetAllUsersAsync()
        {
            List<GetUserModel> usersModel = _mapper.Map<List<GetUserModel>>((await _userRepository.GetAllUsers()));
            return usersModel;
        }

        public async Task<GetUserModel> CreateUserAsync(CreateUserModel userModel)
        {
            if (userModel.Password != userModel.PasswordConfirmation)
                throw new PasswordDoesNotMatchException("Les mots de passe ne sont pas identiques");

            User user = _mapper.Map<User>(userModel);

            user.RegistrationValidated = false;
            user.RoleId = 1;
            return _mapper.Map<GetUserModel>(await _userRepository.CreateUser(user));
        }

        public async Task<GetUserModel> CreateUserWithRoleAsync(CreateUserWithRoleModel userModel)
        {
            User user = _mapper.Map<User>(userModel);
            user.RegistrationValidated = false;
            user.Password = GenerateRandomPassword();

            return _mapper.Map<GetUserModel>(await _userRepository.CreateUser(user));
        }

        public async Task<GetUserModel> UpdateUserAsync(UpdateUserModel userModel)
        {
            User user = _mapper.Map<User>(userModel);
            _userRepository.UpdateUser(user);
            return _mapper.Map<GetUserModel>(user);
        }

        public async Task AskResetPassword(string mail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResetPassword(int idUser, string password, string confirmPassword)
        {
            if(password != confirmPassword)
                return false;

            return await _userRepository.ResetPassword(idUser, password);
        }

        public async Task ConfirmRegistration(int idUser)
        {
            await _userRepository.ConfirmRegistration(idUser);
        }

        public async Task ChangeUserRoleAsync(int idRole, int idUser)
        {
            await _userRepository.ChangeUserRole(idRole, idUser);
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

        public async Task<bool> UserExistWithMail(string email)
        {
            return await _userRepository.GetUserByMail(email) is not null;
        }

        private string GenerateRandomPassword()
        {
            int length = 10;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
