namespace goodfood_user.Services.Interfaces
{
    public interface IUnitOfWork
    {

        Task SaveChangesAsync();
        int SaveChanges();
    }
}
