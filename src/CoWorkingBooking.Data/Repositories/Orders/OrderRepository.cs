using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Domain.Entities.Orders;

namespace CoWorkingBooking.Data.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
