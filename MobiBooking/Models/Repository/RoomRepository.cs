using System;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _context;

        public RoomRepository(BookingDbContext context)
        {
            _context = context;
        }

        public void Add(Room b)
        {
            _context.Rooms.Add(b);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                _context.Rooms.Remove(new Room() { Id = id });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (_context.Rooms.Any(i => i.Id != id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw ex;
                }
            }
        }

        public Room Get(int id)
        {
            return _context.Rooms.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms;
        }

        public void Update(int id, Room b)
        {
            b.Id = id;
            _context.Rooms.Attach(b);
        }
    }
}