using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Data.IRepositories.Users;
using CoWorkingBooking.Data.Repositories.CoWorkings;
using CoWorkingBooking.Data.Repositories.Orders;
using RaqamliAvlod.DataAccess.Repositories.Users;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoWorkingDbContext dbContext;

        public UnitOfWork(CoWorkingDbContext dbContext)
        {
            this.dbContext = dbContext;
            Users = new UserRepository(dbContext);
            CoWorkings = new CoWorkingRepository(dbContext);
            Branches = new BranchRepository(dbContext);
            Orders = new OrderRepository(dbContext);
            Seats = new SeatRepository(dbContext);
            Payments = new PaymentRepository(dbContext);
        }

        public IUserRepository Users { get; }

        public ICoWorkingRepository CoWorkings { get; }

        public IBranchRepository Branches { get; }

        public IOrderRepository Orders { get; }

        public ISeatRepository Seats { get; }

        public IPaymentRepository Payments { get; }


        public async ValueTask SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
