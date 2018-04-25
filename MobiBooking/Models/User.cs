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

        public double MeetingsCurrentWeek { get; set; }
        public double MeetingsPastWeek { get; set; }
        public double MeetingsCurrentMonth { get; set; }
        public double MeetingsPastMonth { get; set; }

        public int ReservationCurrentWeek { get; set; }
        public int ReservationPastWeek { get; set; }
        public int ReservationCurrentMonth { get; set; }
        public int ReservationPastMonth { get; set; }

        public void BookRoom(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        public void CurrentWeek(User user)
        {
            DateTime startOfWeek = DateTime.Today.AddDays((int)(DateTime.Today.DayOfWeek) * -1).AddDays(1);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            
            var stats = foo(startOfWeek, endOfWeek, user);

            user.ReservationCurrentWeek = stats.Item1;
            user.MeetingsCurrentWeek = stats.Item2;

            
            DateTime pastStartWeek = startOfWeek.AddDays(-7);
            DateTime pastEndWeek = startOfWeek.AddDays(-1);

            stats = foo(pastStartWeek, pastEndWeek, user);

            user.ReservationPastWeek = stats.Item1;
            user.MeetingsPastWeek = stats.Item2;

            
            DateTime StartMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime EndMonth = StartMonth.AddMonths(1).AddTicks(-1);

            stats = foo(StartMonth, EndMonth, user);

            user.ReservationCurrentMonth = stats.Item1;
            user.MeetingsCurrentMonth = stats.Item2;
           
            
            DateTime PastStartMonth = StartMonth.AddMonths(-1);
            DateTime PastEndMonth = EndMonth.AddMonths(1).AddTicks(-1);

            stats = foo(PastStartMonth, PastEndMonth, user);

            user.ReservationPastMonth = stats.Item1;
            user.MeetingsPastMonth = stats.Item2;
        }

        private Tuple<int, double> foo(DateTime startDate, DateTime endDate, User user)
        {
            int days = new int();
            double hours = new double();
            List<Reservation> tempReservationsList = new List<Reservation>();

            //sprawdza ktore rejestracje sali mieszczą się w obecnym miesiącu początek lub koniec
            foreach (var item in user.Reservations)
            {
                if ((item.From >= startDate && item.From <= endDate) ||
                    item.To >= startDate && item.To <= endDate)
                {
                    tempReservationsList.Add(item);
                }
            }

            foreach (var item in tempReservationsList)
            {
                int daysOfReservation = (item.To - item.From).Days + 1;

                //odcięcie dni przed poprzednim tygodniem z rezerwacji
                if (item.From < startDate)
                {
                    daysOfReservation -= (startDate - item.From).Days;
                }

                //odcięcie dni po poprzednim tygodniu z rezerwacji
                if (item.To > endDate)
                {
                    daysOfReservation -= (item.To - endDate).Days;
                }

                days += daysOfReservation;

                switch (item.Room.EtimeOption)
                {
                    case TimeOption.timeSet1:
                        hours += days * 8;
                        break;
                    case TimeOption.timeSet2:
                        hours += days * 11;
                        break;
                    case TimeOption.timeSet3:
                        hours += days * 13;
                        break;
                    default:
                        break;
                }
            }

            return Tuple.Create(days, hours);
        }
    }
}