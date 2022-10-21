using goodfood_user.Entities;
using goodfood_user.Models;

namespace goodfood_user.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAllUsers();
        public Task<User> GetUser(int idUser);
        public Task<User> GetUserByMail(string email);
        public Task<User> GetUserByUuid(string uuid);
        public Task<User> CreateUser(User user);
        public Task ConfirmRegistration(int idUser);
        public Task ChangeUserRole(int role, int idUser);
        public Task<bool> ResetPassword(int idUser, string password);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        
    }
}
