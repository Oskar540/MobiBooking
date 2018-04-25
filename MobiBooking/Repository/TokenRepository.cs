using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobiBooking.Exceptions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MobiBooking.Models.Repository
{
    public class TokenRepository : ITokenRepository<User>
    {
        private readonly BookingDbContext _db;
        private readonly IConfiguration _config;

        public TokenRepository(BookingDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public User Create(User login)
        {
            var user = Authenticate(login);

            if (user == null)
            {
                throw new HttpResponseException(401, "Login or password missing!");
            }
            else
            {
                BuildToken(user);
            }

            return user;
        }

        private void BuildToken(User user)
        {
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Login),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("Role", user.Status.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: creds);

            //variable only for stack security token string in local variables
            var printedToken = new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(User login)
        {
            return _db.Users.FirstOrDefault(c => c.Login == login.Login && c.Password == login.Password);
        }
    }
}