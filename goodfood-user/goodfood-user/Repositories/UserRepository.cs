using goodfood_user.Entities;
using goodfood_user.Models;
using goodfood_user.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_user.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetAllUsers() => await _context.Users.ToListAsync();

        public async Task<User> GetUser(int idUser) => (await _context.Users.FirstOrDefaultAsync(u => u.Id == idUser))!;

        public async Task<User> CreateUser(User user)
        {
            user.RegistrationValidated = false;
            await _context.Users.AddAsync(user);
            return user;
        }

        public void UpdateUser(User user) => _context.Users.Update(user);

        public void DeleteUser(User user) => _context.Users.Remove(user);
    }
}
