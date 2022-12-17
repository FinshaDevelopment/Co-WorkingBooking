using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Attributes.User
{
    public class Username : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string login &&
                login.All(c => char.IsDigit(c) ||
                char.IsLetter(c) || c == '_') &&
                login.Any(c => char.IsLetter(c)))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("username should only contain digits, letters and underline");
        }
    }
}
