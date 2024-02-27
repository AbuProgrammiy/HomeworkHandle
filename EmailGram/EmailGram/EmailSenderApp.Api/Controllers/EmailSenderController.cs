using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmailSenderApp.Domen.Entities.Models;
using EmailSenderApp.Application.Services;
using Microsoft.AspNetCore.Identity;

namespace EmailSenderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly ILoginAndRegistrationService _sendEmailService;
        public EmailSenderController(ILoginAndRegistrationService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }



        [HttpPost("SendPasswordForRegistration")]
        public string SendPasswordForRegistration(string email)
        {
            return _sendEmailService.SendPasswordForRegistration(email);
        }

        [HttpPost("CheckPasswordForRegistration")]
        public string CheckPasswordForRegistration(string password)
        {
            return _sendEmailService.CheckPasswordForRegistration(password);
        }

        [HttpPost("LogIn")]
        public string LogIn(UserModel model)
        {
            return _sendEmailService.Login(model);
        }
    }
}
