using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{
    public class TokenRepository : IDefaultRepository<User>
    {

        private readonly BookingDbContext _db;
        private readonly IConfiguration _config;

        public TokenRepository(BookingDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public int Add(User b)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(int id, User b)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create(User login)
        {
            IActionResult response = Unauthorized(); //Unauthorized() does not exist in the current context
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString }); //Ok() does not exist in the current context
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(User login)
        {
            return _db.Users.FirstOrDefault(c => c.Login == login.Login && c.Password == login.Password);
        }
    }
}
