using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.Repositories.Orders
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
