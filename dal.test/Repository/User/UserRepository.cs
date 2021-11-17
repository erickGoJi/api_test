using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using biz.test.Models.Email;
using biz.test.Repository.User;
using biz.test.Services.Email;
using dal.test.Repository.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Web.Helpers;
using dal.test.DBContext;
using Microsoft.Extensions.Configuration;

namespace dal.test.Repository.User;

public class UserRepository : GenericRepository<biz.test.Entities.User>, IUserRepository
{
        private IConfiguration _config;
        private IEmailService _emailservice;

        public UserRepository(Db_Test context, IConfiguration config, IEmailService emailService) : base(context)
        {
            _config = config;
            _emailservice = emailService;
        }

        public string BuildToken(biz.test.Entities.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                // Issuer = ,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public string SendMail(string emailTo, string body, string subject)
        {
            EmailModel email = new EmailModel();
            email.To = emailTo;
            email.Subject = subject;
            email.Body = body;
            email.IsBodyHtml = true;

            return _emailservice.SendEmail(email);
        }

        public string VerifyEmail(string email)
        {
            var result = "";

            if (_context.Users.SingleOrDefault(x => x.Email.ToLower().Trim() == email.ToLower().Trim()) != null)
            {
                result = "Exist";
            }
            else
            {
                result = "No Exist";
            }

            return result;
        }

        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
}