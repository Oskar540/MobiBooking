using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using MobiBooking.Services;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private ITokenRepository<User> _repo;

        public TokenController(ITokenRepository<User> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody]User login)
        {
            if (_repo.Create(login) != null)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public User GetToken(int Id)
        {
            return _repo.Get(Id);
        }
    }
}