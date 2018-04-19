using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private BookingDbContext _db;
        //private UserManager<IdentityUser> _manager;
        public TestController(BookingDbContext db/*, UserManager<IdentityUser> manager*/)
        {
            _db = db;
            //_manager = manager;
        }

        // GET: api/Test
        [HttpGet]
        public string Get()
        {
            return "test";
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _db.Users.FirstOrDefault(c => c.Id == id).Status.ToString(); ;
        }
        
        // POST: api/Test
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
