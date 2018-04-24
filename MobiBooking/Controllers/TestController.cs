using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;
using System.Linq;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private BookingDbContext _db;

        public TestController(BookingDbContext db)
        {
            _db = db;
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
        public string Post([FromBody]logowanie logs)
        {
            return "Witaj " + logs.login.ToString() + " " + logs.password.ToString() + "!!!";
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

        public class logowanie
        {
            public string login { get; set; }
            public string password { get; set; }
        }
    }
}