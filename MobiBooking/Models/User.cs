using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models
{
	public enum propStatus { user, admin}
	
	public class User
	{
		public int Id { get; set; }
		[Required]
		public string login { get; set; }
		[Required]
		public string password { get; set; }
		public string name { get; set; }
		public string lastname { get; set; }
		[Required]
		public string email { get; set; }
		public propStatus epropStatus { get; set;}
		//public List<Room> bookedRooms { get; set; }
		//public int hoursWeek { get; set; }
		//public int hoursMonth { get; set; }
		//public int hoursWeek_past { get; set; }
		//public int hoursMonth_past { get; set; }
		//public int amountWeek { get; set; }
		//public int amountMonth { get; set; }
		//public int amountsWeek_past { get; set; }
		//public int amountMonth_past { get; set; }

		public User(string login, string password, string email)
		{
			this.login = login;
			this.password = password;
			this.email = email;
		}

		//public void Reserve(Room room)
		//{
		//	bookedRooms.Add(room);

		//}
	}
}
