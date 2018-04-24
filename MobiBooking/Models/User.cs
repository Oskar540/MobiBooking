using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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

        public TimeSpan MeetingsCurrentWeek { get; set; }
        public TimeSpan MeetingsPastWeek { get; set; }
        public TimeSpan MeetingsCurrentMonth { get; set; }
        public TimeSpan MeetingsPastMonth { get; set; }

        public int ReservationCurrentWeek { get; set; }
        public int ReservationPastWeek { get; set; }
        public int ReservationCurrentMonth { get; set; }
        public int ReservationPastMonth { get; set; }

        public void BookRoom(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        public void Meetings(List<Reservation> res)
        {
            double days = new double();
            double hours = new double();
            List<Reservation> resWeek = new List<Reservation>();


            //sprawdza ktore rejestracje sali mieszczą się w obecnym tygodniu początek lub koniec
            foreach (var item in res)
            {
                //popraw .DayOfWeek nie zwraca konkretnego tygodnia z roku tylko liczbę dni
                if((item.From.Year == DateTime.Now.Year && item.From.DayOfWeek == DateTime.Now.DayOfWeek) ||
                    item.To.Year == DateTime.Now.Year && item.To.DayOfWeek == DateTime.Now.DayOfWeek)
                {
                    resWeek.Add(item);
                }
            }

             /*
             Z reszty dni z przedziałów from-to wyciąg dni tylko z tego tygodnia
             Z wyciągniętych dni wyciąg tylko zarezerwowane godziny
             */
            
            
            foreach (var item in res)
            {
                days += (item.From - DateTime.Now).TotalDays;

                switch (item.Room.EtimeOption)
                {
                    case TimeOption.timeSet1:
                        {
                            hours += days * 8;
                        }
                        break;
                    case TimeOption.timeSet2:
                        {
                            hours += days * 11;
                        }
                        break;
                    case TimeOption.timeSet3:
                        {
                            hours += days * 13;
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}