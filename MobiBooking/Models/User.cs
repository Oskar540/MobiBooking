using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models
{
	public enum PropStatus { User, Admin}
	
	public class User
	{
		public int Id { get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[Compare(nameof(password))]
        //public string confirmPassword { get; set; }
        public string Name { get; set; }
		public string Lastname { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public new string Email { get; set; }
		public PropStatus EpropStatus { get; set;}
		//public List<Room> bookedRooms { get; set; }
		//public int hoursWeek { get; set; }
		//public int hoursMonth { get; set; }
		//public int hoursWeek_past { get; set; }
		//public int hoursMonth_past { get; set; }
		//public int amountWeek { get; set; }
		//public int amountMonth { get; set; }
		//public int amountsWeek_past { get; set; }
		//public int amountMonth_past { get; set; }
	}
}
