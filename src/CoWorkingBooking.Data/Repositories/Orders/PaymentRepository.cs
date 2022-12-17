using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Domain.Entities.Users;

namespace CoWorkingBooking.Data.Repositories.Orders
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
