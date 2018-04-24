using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobiBooking.DTO;
using MobiBooking.Exceptions;
using MobiBooking.Models.Repository;
using System.Collections.Generic;

namespace MobiBooking.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly IDefaultRepository<RoomDto> _repo;

        public RoomsController(IDefaultRepository<RoomDto> repo)
        {
            _repo = repo ?? throw new HttpResponseException(503, "Issue with connect to repository");
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<RoomDto> GetRooms()
        {
            return _repo.GetAll();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public void GetRoom(int id)
        {
            _repo.Get(id);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void PutRoom(int id, [FromBody] RoomDto room)
        {
            _repo.Update(id, room);
        }

        // POST: api/Rooms
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void PostRoom([FromBody] RoomDto room)
        {
            _repo.Add(room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteRoom(int id)
        {
            _repo.Delete(id);
        }
    }
}