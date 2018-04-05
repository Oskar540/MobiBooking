using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models
{
    public enum timeOption { timeSet1, timeSet2, timeSet3 }
    public enum bookStatus { available, unavailable }


    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public timeOption etimeOption { get; set; }
        public string localization { get; set; }
        public bool isActive { get; set; }
        [Required]
        public int capacity { get; set; }
        public bool isReserved { get; set; }
        public bookStatus ebookStatus { get; set; }

        public Room(string name, string localization, int capacity)
        {
            this.name = name;
            this.localization = localization;
            this.capacity = capacity;
            this.isActive = true;
            etimeOption = 0;
            ebookStatus = 0;
        }
    }
}
