using Microsoft.AspNetCore.Identity;
using System;
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
                throw;
            }
            return id;
        }

        public Room Get(int id)
        {
            return _db.Rooms.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _db.Rooms.OrderBy(c => c.Capacity);
        }

        public int Update(int id, Room b)
        {
            b.Id = id;
            _db.Rooms.Attach(b);
            _db.SaveChanges();

            return b.Id;
        }
    }
}