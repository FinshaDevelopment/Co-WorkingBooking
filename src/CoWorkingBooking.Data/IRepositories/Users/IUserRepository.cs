using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Entities.Users;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.IRepositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {

        public ValueTask<User> GetByUsernameAsync(string username);

        public ValueTask<User> GetByPhoneNumberAsync(string phoneNumber);
    }
}
