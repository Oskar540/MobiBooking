using Newtonsoft.Json;
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

        public void CurrentWeek(User user, List<Reservation> res)
        {
            int days = new int();
            double hours = new double();
            List<Reservation> tempReservationsList = new List<Reservation>();
            DateTime startOfWeek = DateTime.Today.AddDays((int)(DateTime.Today.DayOfWeek) * -1).AddDays(1);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            //sprawdza ktore rejestracje sali mieszczą się w obecnym tygodniu początek lub koniec
            foreach (var item in res)
            {
                if ((item.From >= startOfWeek && item.From <= endOfWeek) ||
                    item.To >= startOfWeek && item.To <= endOfWeek)
                {
                    tempReservationsList.Add(item);
                }
            }

            /*
             Z reszty dni z przedziałów from-to wyciąg dni tylko z tego tygodnia
             Z wyciągniętych dni wyciąg tylko zarezerwowane godziny
            */


            foreach (var item in tempReservationsList)
            {
                int daysOfReservation = (item.To - item.From).Days + 1;

                //odcięcie dni przed obecnym tygodniem z rezerwacji
                if (item.From < startOfWeek)
                {
                    daysOfReservation -= (startOfWeek - item.From).Days;
                }

                //odcięcie dni po obecnym tygodniu z rezerwacji
                if (item.To > endOfWeek)
                {
                    daysOfReservation -= (item.To - endOfWeek).Days;
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
            user.MeetingsCurrentWeek = hours;
            user.ReservationCurrentWeek = days;


            tempReservationsList.Clear();
            hours = 0;
            days = 0;
            DateTime pastStartWeek = startOfWeek.AddDays(-7);
            DateTime pastEndWeek = startOfWeek.AddDays(-1);

            //sprawdza ktore rejestracje sali mieszczą się w poprzednim tygodniu początek lub koniec
            foreach (var item in res)
            {
                if ((item.From >= startOfWeek && item.From <= endOfWeek) ||
                    item.To >= startOfWeek && item.To <= endOfWeek)
                {
                    tempReservationsList.Add(item);
                }
            }

            /*
             Z reszty dni z przedziałów from-to wyciąg dni tylko z tego tygodnia
             Z wyciągniętych dni wyciąg tylko zarezerwowane godziny
            */


            foreach (var item in tempReservationsList)
            {
                int daysOfReservation = (item.To - item.From).Days + 1;

                //odcięcie dni przed poprzednim tygodniem z rezerwacji
                if (item.From < pastStartWeek)
                {
                    daysOfReservation -= (pastStartWeek - item.From).Days;
                }

                //odcięcie dni po poprzednim tygodniu z rezerwacji
                if (item.To > pastEndWeek)
                {
                    daysOfReservation -= (item.To - pastEndWeek).Days;
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
            user.MeetingsPastWeek = hours;
            user.ReservationPastWeek = days;


            tempReservationsList.Clear();
            hours = 0;
            days = 0;
            DateTime StartMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime EndMonth = StartMonth.AddMonths(1).AddTicks(-1);

            //sprawdza ktore rejestracje sali mieszczą się w obecnym miesiącu początek lub koniec
            foreach (var item in res)
            {
                if ((item.From >= StartMonth && item.From <= EndMonth) ||
                    item.To >= StartMonth && item.To <= EndMonth)
                {
                    tempReservationsList.Add(item);
                }
            }

            foreach (var item in tempReservationsList)
            {
                int daysOfReservation = (item.To - item.From).Days + 1;

                //odcięcie dni przed poprzednim tygodniem z rezerwacji
                if (item.From < StartMonth)
                {
                    daysOfReservation -= (StartMonth - item.From).Days;
                }

                //odcięcie dni po poprzednim tygodniu z rezerwacji
                if (item.To > EndMonth)
                {
                    daysOfReservation -= (item.To - EndMonth).Days;
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
            user.MeetingsCurrentMonth = hours;
            user.ReservationCurrentMonth = days;


            tempReservationsList.Clear();
            hours = 0;
            days = 0;
            DateTime PastStartMonth = StartMonth.AddMonths(-1);
            DateTime PastEndMonth = EndMonth.AddMonths(1).AddTicks(-1);

            //sprawdza ktore rejestracje sali mieszczą się w obecnym miesiącu początek lub koniec
            foreach (var item in res)
            {
                if ((item.From >= PastStartMonth && item.From <= PastEndMonth) ||
                    item.To >= PastStartMonth && item.To <= PastEndMonth)
                {
                    tempReservationsList.Add(item);
                }
            }

            foreach (var item in tempReservationsList)
            {
                int daysOfReservation = (item.To - item.From).Days + 1;

                //odcięcie dni przed poprzednim tygodniem z rezerwacji
                if (item.From < PastStartMonth)
                {
                    daysOfReservation -= (PastStartMonth - item.From).Days;
                }

                //odcięcie dni po poprzednim tygodniu z rezerwacji
                if (item.To > PastEndMonth)
                {
                    daysOfReservation -= (item.To - PastEndMonth).Days;
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
            user.MeetingsPastMonth = hours;
            user.ReservationPastMonth = days;
        }
    }
}