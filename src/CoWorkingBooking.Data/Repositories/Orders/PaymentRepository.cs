using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Domain.Entities.Orders;

namespace CoWorkingBooking.Data.Repositories.Orders
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
