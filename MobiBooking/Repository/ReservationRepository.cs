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
            _db = db;
        }

        public int Add(Reservation b)
        {
            b.Room = _db.Rooms.FirstOrDefault(c => c.Id == b.Room.Id);
            _db.Reservations.Add(b);
            _db.SaveChanges();
            return b.Id;
        }

        public int Delete(int id)
        {
            var reservation = _db.Reservations.FirstOrDefault(c => c.Id == id);
            if (reservation == null)
            {
                throw new HttpResponseException(404, "Can't find reservation with this identifier!");

            }
            _db.Reservations.Remove(reservation);
            _db.SaveChanges();
            
            return id;
        }

        public Reservation Get(int id)
        {
            var reservation = _db.Reservations.FirstOrDefault(c => c.Id == id);
            if(!reservation.CheckIfCycledOrEnd(reservation))
            {
                _db.Reservations.Remove(reservation);
            }
            if(reservation == null)
            {
                throw new HttpResponseException(404, "Can't find reservation with this identifier!");
            }

            return reservation;
        }

        public IEnumerable<Reservation> GetAll(string param)
        {
            var propertyInfo = typeof(Reservation).GetProperty(param);
            return _db.Reservations.OrderBy(c => propertyInfo.GetValue(c, null));
        }

        public int Update(int id, Reservation item)
        {
            var reservation = _db.Reservations.FirstOrDefault(c => c.Id == id);
            if (reservation == null)
            {
                throw new HttpResponseException(404, "Can't find reservation with this identifier!");
            }
            try
            {
                reservation.Room = _db.Rooms.FirstOrDefault(c => c.Id == item.Room.Id);
                reservation.From = item.From;
                reservation.To = item.To;
                reservation.ExtraEquip = item.ExtraEquip;
                reservation.Title = item.Title;
                reservation.IsCycled = item.IsCycled;
                _db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(400, "Invalid sended data!");
            }
            return reservation.Id;
        }
    }
}