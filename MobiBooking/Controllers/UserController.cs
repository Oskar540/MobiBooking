using Microsoft.AspNetCore.Mvc;
using MobiBooking.DTO;
using MobiBooking.Models.Repository;
using System.Collections.Generic;
using MobiBooking.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private IDefaultRepository<UserDto> _repo;

        public UserController(IDefaultRepository<UserDto> repo)
        {
            _repo = repo;
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
        public int PutUserById(int id, [FromBody]UserDto item)
        {
            int userId = _repo.Update(item.Id, item);

            return userId;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteById(int id)
        {
            return _repo.Delete(id);
        }
    }
}