using goodfood_products.Entities;
using goodfood_products.Services.Interfaces;

namespace goodfood_products.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext context;

        public UnitOfWork(ProductContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();

        public int SaveChanges() =>
            context.SaveChanges();
    }
}
