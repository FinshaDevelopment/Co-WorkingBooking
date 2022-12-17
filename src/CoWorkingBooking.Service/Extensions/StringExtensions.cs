using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Extensions
{
    public static class StringExtensions
    {
        public static string Encrypt(this string password)
        {
            using (SHA256 sha256HASH = SHA256.Create())
            {
                var hashedBytes = sha256HASH.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hashedPassword;
            }
        }
    }
}
