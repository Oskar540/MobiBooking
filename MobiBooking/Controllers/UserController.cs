using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using Microsoft.AspNetCore.Authentication;
using MobiBooking.Models.DataManager;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private IUserRepository _repo;
        //private bool isAuth;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
            //isAuth = User.Identity.IsAuthenticated;
        }

        [Authorize(Roles = "Admin")]
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            
            return _repo.GetAll().OrderBy(c => c.Name);
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello get";
        //}

        // GET: api/User/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _repo.GetByID(id);
        }
        

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _repo.Add(user);
        }

        // PUT: api/User/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            _repo.Update(user.Id, user);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteByID(id);
        }

    }
}
