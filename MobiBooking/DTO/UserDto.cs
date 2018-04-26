using System.Collections.Generic;

namespace MobiBooking.DTO
{
    public enum PropStatus { User, Admin }

    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public PropStatus Status { get; set; }
        public List<ReservationDto> Reservations { get; set; }
        public List<ReservationDto> Invitings { get; set; }
        public double MeetingsCurrentWeek { get; set; }
        public double MeetingsPastWeek { get; set; }
        public double MeetingsCurrentMonth { get; set; }
        public double MeetingsPastMonth { get; set; }
        public int ReservationCurrentWeek { get; set; }
        public int ReservationPastWeek { get; set; }
        public int ReservationCurrentMonth { get; set; }
        public int ReservationPastMonth { get; set; }

        public void BookRoom(ReservationDto reservation)
        {
            Reservations.Add(reservation);
        }
    }
}