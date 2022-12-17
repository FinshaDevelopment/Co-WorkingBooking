using CoWorkingBooking.Domain.Commons;
using CoWorkingBooking.Domain.Enums;

namespace CoWorkingBooking.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
