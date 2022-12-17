
using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.Interfaces.Users;
using CoWorkingBooking.Data.Repositories;
using CoWorkingBooking.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RaqamliAvlod.DataAccess.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CoWorkingDbContext context) : base(context)
        {

        }

        public async Task<User> GetByUsernameAsync(string username)
            => await dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);

        public async Task<User> GetByPhonNumberAsync(string phoneNumber)
            => await dbContext.Users.FirstOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
        
    }
}
