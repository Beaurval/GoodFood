using goodfood_user.Models.Role;
using goodfood_user.Models.User;

namespace goodfood_user.Services.Interfaces
{
    public interface IUserService
    {
        public Task<GetUserModel> GetUserAsync(int idUser);
        public Task<ICollection<GetUserModel>> GetAllUsersAsync();
        public Task<GetUserModel> CreateUserAsync(CreateUserModel user);
        public Task<GetUserModel> CreateUserWithRoleAsync(CreateUserModel user, GetRoleModel role);
        public Task<GetUserModel> UpdateUserAsync(UpdateUserModel user);
        public Task AskResetPassword(string mail);
        public Task<bool> ResetPassword(int idUser, string password, string confirmPassword);
        public Task ConfirmRegistration(int idUser);
        public Task ChangeUserRoleAsync(int idRole, int idUser);
        public Task DeleteUser(int idUser);
        public Task<bool> UserExist(int idUser);
    }
}
