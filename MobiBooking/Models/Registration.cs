using System.ComponentModel.DataAnnotations;

namespace MobiBooking.Models
{
    public class Registration : User
    {
        [Required]
        public new string Login { get; set; }

        [Required, DataType(DataType.Password)]
        public new string Password { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public new string Email { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}