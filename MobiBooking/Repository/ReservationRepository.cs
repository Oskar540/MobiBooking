using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Repository
{
    public class ReservationRepository : IDefaultRepository<Reservation>
    {
        private BookingDbContext _db;

        public ReservationRepository(BookingDbContext db)
        {
            _db = db;
        }

        public int Add(Reservation b)
        {
            _db.Reservations.Add(b);
            _db.SaveChanges();
            return b.Id;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Reservations.Remove(new Reservation() { Id = id });
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
            return id;
        }

        public Reservation Get(int id)
        {
            return _db.Reservations.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _db.Reservations.OrderBy(c => c.From);
        }

        public int Update(int id, Reservation b)
        {
            b.Id = id;
            _db.Reservations.Attach(b);
            _db.SaveChanges();

            return b.Id;
        }
    }
}
