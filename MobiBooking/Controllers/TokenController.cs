using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.DTO;
using MobiBooking.Exceptions;
using MobiBooking.Models.Repository;

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
            _repo = repo ?? throw new HttpResponseException(503, "Issue with connect to repository");
        }

        //[HttpGet]
        //[Route("/login")]
        //public string GetLoginUser(string login, string password)
        //{
        //    return "Hello " + _repo.GetLoginUser(login, password).Name;
        //}

        [HttpPost]
        [Route("/login")]
        public UserDto CreateToken([FromBody]UserDto login)
        {
            return _repo.Create(login);
        }
    }
}