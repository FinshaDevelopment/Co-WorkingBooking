using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Attributes.User
{
    public class Password : ValidationAttribute
    {
        public override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string password &&
                password.Length >= 8 &&
                password.Any(c => char.IsDigit(c)) &&
                password.Any(c => char.IsLetter(c)))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Password should contain at least 8 characters," +
                                                    " should contain at least on letter and digit");
        } }
}
