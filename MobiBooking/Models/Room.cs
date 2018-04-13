using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models
{
    public enum TimeOption { timeSet1, timeSet2, timeSet3 }
    public enum BookStatus { available, unavailable }


    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeOption EtimeOption { get; set; }
        public string Localization { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public BookStatus EbookStatus { get; set; }

        public Room(string name, string localization, int capacity)
        {
            this.Name = name;
            this.Localization = localization;
            this.Capacity = capacity;
            this.IsActive = true;
            EtimeOption = 0;
            EbookStatus = 0;
        }
    }
}
