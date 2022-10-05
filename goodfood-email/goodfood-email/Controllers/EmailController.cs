//send tempory password -> recois un mdp et un password et l'envois au man

using goodfood_email.Service;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_email.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly  IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {

            _emailService = emailService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [Route("verif")]
        [HttpPost]
        public async Task<IActionResult> SendMailVerificationAsync([FromForm] string Email)
        {

            await _emailService.SendMailVerificationAsync(Email);
            return Ok();


        }

        [Route("reset")]
        [HttpPost]
        public async Task<IActionResult> SendResetPasswordAsync([FromForm] string Email)
        {

            await _emailService.SendResetPasswordAsync(Email);
            return Ok();


        }

        [Route("status")]
        [HttpPost]
        public async Task<IActionResult> SendNewStatusCommandAsync([FromForm]  string Email, [FromForm] int idCommande)
        {

            await _emailService.SendNewStatusCommandAsync(Email, idCommande);
            return Ok();


        }
    }
}
