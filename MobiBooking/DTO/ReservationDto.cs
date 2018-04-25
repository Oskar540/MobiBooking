using System;
using System.Collections.Generic;

namespace MobiBooking.DTO
{
    public enum ExtraEquipment { None, Flipchart, SoundSystem }

    public class ReservationDto
    {
        public int Id { get; set; }
        public RoomDto Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ExtraEquipment ExtraEquip { get; set; }
        public string Title { get; set; }
        public bool IsCycled { get; set; } = false;
    }
}