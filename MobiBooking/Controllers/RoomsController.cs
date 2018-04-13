using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System.Collections.Generic;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly IDefaultRepository<Room> _repo;

        public RoomsController(IDefaultRepository<Room> repo)
        {
            _repo = repo;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Room> GetRooms()
        {
            return _repo.GetAll();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public void GetRoom([FromRoute] int id)
        {
            _repo.Get(id);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public void PutRoom([FromRoute] int id, [FromBody] Room room)
        {
            _repo.Update(id, room);
        }

        // POST: api/Rooms
        [HttpPost]
        public void PostRoom([FromBody] Room room)
        {
            _repo.Add(room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public void DeleteRoom([FromRoute] int id)
        {
            _repo.Delete(id);
        }
    }
}