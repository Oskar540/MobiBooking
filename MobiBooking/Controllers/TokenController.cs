using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MobiBooking.Models;
using MobiBooking.Models.Repository;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private ITokenRepository<User> _repo;
        private readonly IMapper _mapper;

        public TokenController(ITokenRepository<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
    }
}