﻿using MobiBooking.Exceptions;
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
            if(reservation == null)
            {
                throw new HttpResponseException(404, "Can't find reservation with this identifier!");

            }

            return reservation;
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