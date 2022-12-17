using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoWorkingBooking.Service.Attributes.User
{
    public class PhoneNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) =>
            value is string phoneNumber && phoneNumber.Length == 12 &&
                phoneNumber.All(c => char.IsDigit(c))
                    ? ValidationResult.Success
                    : new ValidationResult("Number can only contain numbers and length of it should be 12");
    }
}
