using System.Threading.Tasks;

namespace RaqamliAvlod.DataAccess.Interfaces.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {

        public ValueTask<User> GetByUsernameAsync(string username);

        public ValueTask<User> GetByPhoneNumberAsync(string phoneNumber);
    }
}
