using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public int capacity { get; set; }
    }
}
