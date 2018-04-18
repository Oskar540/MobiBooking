using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.DTO;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using MobiBooking.Services;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private IDefaultRepository<UserDto> _repo;
        private BookingDbContext _db;

        public UserController(IDefaultRepository<UserDto> repo, BookingDbContext db)
        {
            _repo = repo;
            _db = db;
        }
        
        // GET: api/User
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return _repo.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public UserDto GetbyId(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public int PostNewUser([FromBody]UserDto user)
        {
            return _repo.Add(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public int PutUserById(int id, [FromBody]UserDto user)
        {
            return _repo.Update(user.Id, user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteById(int id)
        {
            return _repo.Delete(id);
        }
    }
}