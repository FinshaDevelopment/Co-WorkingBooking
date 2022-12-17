using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Attributes.User
{
    public class UserLogin : ValidationAttribute
    {
        public override bool IsValid(object value)
            => value is string login &&
                login.All(c => char.IsDigit(c) ||
                char.IsLetter(c) || c == '_') &&
                login.Any(c => char.IsLetter(c));
    }
}
