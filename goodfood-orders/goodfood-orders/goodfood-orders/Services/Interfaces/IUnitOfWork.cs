namespace goodfood_orders.Services.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        int SaveChanges();
    }
}
