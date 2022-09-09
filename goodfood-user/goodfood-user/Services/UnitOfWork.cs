using goodfood_user.Entities;
using goodfood_user.Services.Interfaces;

namespace goodfood_user.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext context;

        public UnitOfWork(UserContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();

        public int SaveChanges() =>
            context.SaveChanges();
    }
}
