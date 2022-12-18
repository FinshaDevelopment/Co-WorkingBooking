using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Data.IRepositories.Users;
using System.Threading.Tasks;

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
