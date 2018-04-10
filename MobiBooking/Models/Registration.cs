using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models
{
    public class Registration : User
    {
        [Required]
        public string login { get; set; }
        [Required, DataType(DataType.Password)]
        public string password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Compare(nameof(password))]
        public string confirmPassword { get; set; }
    }
}
