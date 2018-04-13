using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private IDefaultRepository<User> _repo;

        public TokenController(IConfiguration config, IDefaultRepository<User> repo, BookingDbContext db)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody]User login)
        {
            return _repo.Create(login);
        }
    }
}