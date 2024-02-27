using EmailSenderApp.Domen.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EmailSenderApp.Infrastructure;

namespace EmailSenderApp.Application.Services
{
    public class LoginAndRegistrationService : ILoginAndRegistrationService
    {
        public string Email;
        public Random random = new Random();
        private IConfiguration _config;
        public ApplicationDbContext _context;

        public LoginAndRegistrationService(IConfiguration config,ApplicationDbContext context)
        {
            _context=context;
            _config = config;
        }

        public string CheckPasswordForRegistration(string password)
        {
            int originalPassword = int.Parse(File.ReadAllText("C:/LastPassword.txt").Split(":")[1]);
            if(password==originalPassword.ToString())
            {
                UserModel userModel = new UserModel()
                {
                    Email = File.ReadAllText("C:/LastPassword.txt").Split(":")[0],
                    Password = originalPassword.ToString(),
                };
                _context.AddAsync(userModel).GetAwaiter().GetResult();
                _context.SaveChangesAsync().GetAwaiter().GetResult();
                string Email = File.ReadAllText("C:/LastPassword.txt").Split(":")[0];
                return $"Registratsiyadan o'tingiz\nEndi siznig\nEmailingz: {Email}\nPasswordingiz: {originalPassword}\nLogin uchun ishlatasiz endi!)";
            }
            return "Notogri password\nQayta urinish bepul!";
        }

        public string Login(UserModel emailModel)
        {
            UserModel model= _context.userModels.FirstOrDefault(x=> x.Email==emailModel.Email)!;
            if (model.Email != emailModel.Email)
            {
                return "Ukajonim ozincha aldab yo emailni kiritb Login qimoqchimidn\nOldin registratsiyadan o't!";
            }
            else if(model.Password != emailModel.Password)
            {
                return "Paswordni estan chqarib qoyibsanu ukajonim\n Yahsilab o'lab kor passwrdni!";
            }
            return "Okajonim muvafaqiyatli Login qildiz,\nBuyurin bizaga nma hizmat";
        }

        public string SendPasswordForRegistration(string email)
        {
            if(_context.userModels.FirstOrDefault(x=>x.Email==email).Email==email)
            {
                return "Ukajonim emailni kimdur-dan uhlatvoganmisan?\nRegistratsiyadan otb bogan bu email! ";
            }
            Email = email;
            int Password=random.Next(1000,9999);
            IConfigurationSection? emailSettings = _config.GetSection("EmailSettings");
            MailMessage? mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"]!, emailSettings["SenderName"]),
                Subject = "Password For Registration",
                Body = $"Your password: {Password}",
                IsBodyHtml = true,

            };
            mailMessage.To.Add(email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]!))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };


            //smtpClient.UseDefaultCredentials = true;
            smtpClient.SendMailAsync(mailMessage).GetAwaiter().GetResult();

            File.WriteAllText("C:/LastPassword.txt", $"{Email}:{Password}");
            return "Passwordi Jo'natvordu emailizga!";
        }
    }
}
