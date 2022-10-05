namespace goodfood_provider.Services.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        int SaveChanges();
    }
}