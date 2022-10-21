using Microsoft.EntityFrameworkCore;

namespace goodfood_user.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role {Id = 1, Name = "Customer"});
            modelBuilder.Entity<User>().Property(m => m.Uuid).IsRequired(false);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
