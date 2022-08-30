using goodfood_user.Models.User;

namespace goodfood_user.Services.Interfaces
{
    public interface IUserService
    {
        public Task<GetUserModel> GetUserAsync(int id);
        public Task<ICollection<GetUserModel>> GetAllUsersAsync();
        public Task<GetUserModel> CreateUserAsync(CreateUserModel user);
        public Task<GetUserModel> UpdateUserAsync(UpdateUserModel user);
        public Task DeleteUser(int id);
        public Task<bool> UserExist(int id);
    }
}
