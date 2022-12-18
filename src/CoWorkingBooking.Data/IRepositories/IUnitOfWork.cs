using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Data.IRepositories.Orders;
using System.Threading.Tasks;
using CoWorkingBooking.Data.IRepositories.Users;

namespace CoWorkingBooking.Data.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICoWorkingRepository CoWorkings { get; }
        IBranchRepository Branches { get; }
        IOrderRepository Orders { get; }
        ISeatRepository Seats { get; }

        ValueTask SaveChangesAsync();
    }
}
