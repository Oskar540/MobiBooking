using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;
using MobiBooking.Models.Repository;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IDataRepository<User, int> _iRepo;
        public UserController(IDataRepository<User, int> repo)
        {
            _iRepo = repo;
        }

        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            return _iRepo.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _iRepo.Get(id);
        }
        
        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _iRepo.Add(user);
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            _iRepo.Update(user.Id, user);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}
