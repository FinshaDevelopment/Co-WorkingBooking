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
        public override bool IsValid(object value)
            => value is string password &&
                password.Length >= 8 &&
                    password.Any(c => char.IsDigit(c)) &&
                        password.Any(c => char.IsLetter(c));
    }
}
