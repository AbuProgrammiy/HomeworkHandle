using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderApp.Domen.Entities.Models;

namespace EmailSenderApp.Application.Services
{
    public interface ILoginAndRegistrationService
    {
        public string Login(UserModel emailModel);
        public string SendPasswordForRegistration(string email);
        public string CheckPasswordForRegistration(string password);
    }
}
