using CoWorkingBooking.Domain.Commons;
using CoWorkingBooking.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Domain.Entities.Users
{
    public class User : Auditable
    {
        [MaxLength(32)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        [MaxLength (64)]
        public string Username { get; set; }
        [MaxLength(128)]
        public string Password { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
