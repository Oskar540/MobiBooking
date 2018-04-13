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
        public string Login { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
