using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.DTO
{
    public enum ExtraExuipment { None, Flipchart, SoundSystem }

    public class ReservationDto
    {
        public int Id { get; set; }
        public RoomDto Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ExtraExuipment ExtraEquip { get; set; }
        public string Title { get; set; }
        public bool IsCycled{ get; set; }
    }
}
