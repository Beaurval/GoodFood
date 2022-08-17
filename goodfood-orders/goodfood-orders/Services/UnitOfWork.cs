using goodfood_orders.Entities;
using goodfood_orders.Services.Interfaces;

namespace goodfood_orders.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderContext context;

        public UnitOfWork(OrderContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync() =>
            await context.SaveChangesAsync();

        public int SaveChanges() =>
            context.SaveChanges();
    }
}
