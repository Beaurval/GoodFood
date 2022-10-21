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
            context.Database.EnsureCreated();
        }

        public async Task<ICollection<User>> GetAllUsers() => await _context.Users.ToListAsync();

        public async Task<User> GetUser(int idUser) => (await _context.Users.FirstOrDefaultAsync(u => u.Id == idUser))!;
        public async Task<User> GetUserByMail(string email)
        {
            return (await _context.Users.FirstOrDefaultAsync(u => u.Email == email))!;
        }

        public async Task<User> GetUserByUuid(string uuid)
        {
            return (await _context.Users.FirstOrDefaultAsync(u => u.Uuid == uuid))!;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }


        public async Task ConfirmRegistration(int idUser)
        {
            User user = await GetUser(idUser);

            user.RegistrationValidated = true;
            _context.Users.Update(user);
        }

        public async Task ChangeUserRole(int idRole, int idUser)
        {
            User user = await GetUser(idUser);
            user.RoleId = idRole;

            _context.Set<User>().Update(user);
        }

        public async Task<bool> ResetPassword(int idUser, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == idUser);
            if (user == null)
                return false;

            user.Password = password;
            UpdateUser(user);

            return true;
        }

        public void UpdateUser(User user)
        {
            
            _context.ChangeTracker.Clear();
            _context.Users.Update(user);
        }

        public void DeleteUser(User user) => _context.Users.Remove(user);
    }
}
