using goodfood_provider.Entities;
using goodfood_provider.Services.Interfaces;

namespace goodfood_provider.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProviderContext context;

        public UnitOfWork(ProviderContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();

        public int SaveChanges() =>
            context.SaveChanges();
    }
}