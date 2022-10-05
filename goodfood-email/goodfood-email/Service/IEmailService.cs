namespace goodfood_email.Service
{
    public interface IEmailService
    {
        Task SendResetPasswordAsync(string Email);
        Task SendMailVerificationAsync(string Email);
        Task<Task> SendNewStatusCommandAsync(string Email, int idCommande);
    }
}
