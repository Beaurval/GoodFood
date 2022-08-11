namespace goodfood_products.Services.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        int SaveChanges();
    }
}
