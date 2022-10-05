using goodfood_email.Entities;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace goodfood_email.Service
{
    public class EmailService : IEmailService
    {
        private string URLSERVICE = "https://prod-68.westeurope.logic.azure.com:443/workflows/458c2dc62cb64bdab33b4ecd7869377f/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dgEBKemw1KhqnkN1nkGQs-cgSJzmyP3dUC7_YMZ93NU";
        private string URLSERVICE2 = "https://localhost:7186/api/provider/";
        private async Task MailerAsync(string Email, string Objet, string Corps)
        {
            using var client = new HttpClient();
            var jsonData = JsonSerializer.Serialize(new
            {
                corps = Corps,
                email = Email,
                objet = Objet
            });
            HttpResponseMessage result = await client.PostAsync(
                URLSERVICE,
                new StringContent(jsonData, Encoding.UTF8, "application/json"));
            var statusCode = result.StatusCode.ToString();
        }
        public Task SendMailVerificationAsync(string Email)
        {
            string Objet = "NoReply - GoodFood ! Verifiez votre adresse mail";
            string Corps = "Bonjour, pour verifier votre adresse mail veuillez cliquez sur le lien suivant : JE SUIS LE LIEN";
            MailerAsync(Email, Objet, Corps);
            return Task.CompletedTask;
        }


        public Task SendResetPasswordAsync(string Email)
        {
            string Objet = "NoReply - GoodFood ! Reset your password";
            string Corps = "Bonjour, pour modifier votre mot de passe veuillez cliquez sur le lien suivant : JE SUIS LE LIEN";
            MailerAsync(Email, Objet, Corps);
            return Task.CompletedTask;

        }

        public async Task<Task> SendNewStatusCommandAsync(string Email, int idCommande)
        {
            using var client3 = new HttpClient();
            string response = await(await client3.GetAsync(URLSERVICE2 + idCommande)).Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions();
            option.PropertyNameCaseInsensitive = true;
            option.Converters.Add(new JsonStringEnumConverter());
            Provider provider = JsonSerializer.Deserialize<Provider>(response, option);
            
            string Objet = "NoReply - GoodFood ! Status sur votre commande";
            string Corps = "Bonjour, Votre commande est "+"En cour de livraison"+"Recapitulatif de votre commande chez "+ provider.Name + " : ";
            MailerAsync(Email, Objet, Corps);
            return Task.CompletedTask;

        }

    }
}
