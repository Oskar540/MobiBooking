using MobiBooking.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.Repository
{
    public class RoomRepository : IDefaultRepository<Room>
    {
        private readonly BookingDbContext _db;

        public RoomRepository(BookingDbContext db)
        {
            _db = db;

        }

        public int Add(Room b)
        {
            _db.Rooms.Add(b);
            _db.SaveChanges();
            return b.Id;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Rooms.Remove(new Room() { Id = id });
                _db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(404, "Can't find room with this identifier!");
            }
            return id;
        }

        public Room Get(int id)
        {
            var room = _db.Rooms.FirstOrDefault(c => c.Id == id);
            if(room == null)
            {
                throw new HttpResponseException(404, "Can't find room with this identifier!");
            }
            return room;
        }

        public IEnumerable<Room> GetAll()
        {
            return _db.Rooms.OrderBy(c => c.Name);
        }

        public int Update(int id, Room b)
        {
            try
            {
                b.Id = id;
                _db.Rooms.Attach(b);
                _db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(400, "Invalid sended data!");
            }
            return b.Id;
        }
    }
}