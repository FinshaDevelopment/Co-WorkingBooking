using CoWorkingBooking.Service.Attributes.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Users
{
    public class UserForUpdateDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, Username]
        public string Username { get; set; }
        [Required, Password]
        public string Password { get; set; }
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
