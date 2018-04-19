using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MobiBooking.DTO;
using MobiBooking.Models.Repository;
using MobiBooking.Services;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private ITokenRepository<UserDto> _repo;

        public TokenController(ITokenRepository<UserDto> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody]UserDto login)
        {
            var user = _repo.Create(login);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}