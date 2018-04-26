using System;
using System.Collections.Generic;

namespace MobiBooking.Models
{
    public enum ExtraEquipment { None, Flipchart, SoundSystem }

    public class Reservation
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ExtraEquipment ExtraEquip { get; set; }
        public string Title { get; set; }
        public bool IsCycled { get; set; } = false;

        public bool CheckIfCycledOrEnd(Reservation res)
        {
            if(res.To >= DateTime.Now)
            {
                if(IsCycled)
                {
                    var diff = (res.To - res.From).Days;
                    res.From = res.To;
                    res.To = res.To.AddDays(diff);
                }
                else
                {
                    res = null;
                    return false;
                }
            }
            return true;
        }
    }
}