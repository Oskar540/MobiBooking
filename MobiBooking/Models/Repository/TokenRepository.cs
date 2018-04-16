﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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

            if (user != null)
            {
                BuildToken(user);
            }

            return user;
        }

        private void BuildToken(User user)
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
        }

        private User Authenticate(User login)
        {
            return _db.Users.FirstOrDefault(c => c.Login == login.Login && c.Password == login.Password);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}