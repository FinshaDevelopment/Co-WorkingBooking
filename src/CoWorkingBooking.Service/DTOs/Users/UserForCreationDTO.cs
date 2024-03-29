﻿using CoWorkingBooking.Service.Attributes.User;
using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.Users
{
    public class UserForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, Username]
        public string Username { get; set; }
        [Required, Password]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
