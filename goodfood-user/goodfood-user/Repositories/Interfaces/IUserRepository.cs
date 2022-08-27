using goodfood_user.Entities;
using goodfood_user.Models;

namespace goodfood_user.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAllUsers();
        public Task<User> GetUser(int idUser);
        public Task<User> CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
