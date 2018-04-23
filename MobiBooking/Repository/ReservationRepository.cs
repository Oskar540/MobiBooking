using MobiBooking.Exceptions;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Repository
{
    public class ReservationRepository : IDefaultRepository<Reservation>
    {
        private BookingDbContext _db;

        public ReservationRepository(BookingDbContext db)
        {
            _db = db ?? throw new HttpResponseException(503, "Issue with connect to DataBase Context");
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
                throw new HttpResponseException(404, "Can't find reservation with this identifier!");

            }
            return id;
        }

        public Reservation Get(int id)
        {
            var res = _db.Reservations.FirstOrDefault(c => c.Id == id);
            if(res == null)
            {
                throw new HttpResponseException(404, "Can't find reservation with this identifier!");

            }
            return res;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _db.Reservations.OrderBy(c => c.From);
        }

        public int Update(int id, Reservation b)
        {
            try
            {
                b.Id = id;
                _db.Reservations.Attach(b);
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