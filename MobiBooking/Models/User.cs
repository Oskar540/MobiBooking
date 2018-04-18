using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobiBooking.Models
{
    public enum PropStatus { User, Admin }

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public PropStatus Status { get; set; }

        public List<Reservation> Reservations { get; set; }

        public void BookRoom(Reservation reservation)
        {
            Reservations.Add(reservation);
        }
    }
}