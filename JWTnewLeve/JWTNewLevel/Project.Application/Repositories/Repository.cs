using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Services.AuthServices;
using Project.Domen.Entities.Models;
using Project.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _config;

        public Repository(ApplicationDbContext context,IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public string Create(User user)
        {
            user.Token = TokenGenerator(user);
            _context.users.Add(user);
            _context.SaveChanges();
            return "Yangi User va uning tokeni databasaga qoshildi";
        }

        public string Delete(int id)
        {
            User model = _context.users.FirstOrDefault(x => x.Id == id)!;
            _context.users.Remove(model);
            _context.SaveChanges();
            return "Ochrildi";
        }

        public IEnumerable<User> Read()
        {
            return _context.users.ToList();
        }

        public string Update(int id, User user)
        {
            User model=_context.users.FirstOrDefault(x => x.Id == id);
            _context.users.Update(model!);
            return "Ozgardi";
        }



        private string TokenGenerator(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWT:Expire"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),

                new Claim("UserName",user.UserName!),
                new Claim(ClaimTypes.Role,user.Role!),
                new Claim("isAdmin",user.IsAdmin.ToString()),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
