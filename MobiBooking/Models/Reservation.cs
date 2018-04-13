using System;

namespace MobiBooking.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Capacity { get; set; }
    }
}