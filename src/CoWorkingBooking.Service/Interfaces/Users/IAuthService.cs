using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Interfaces.Users
{
    public interface IAuthService
    {
        ValueTask<string> GenerateToken(string username, string password);
    }
}
