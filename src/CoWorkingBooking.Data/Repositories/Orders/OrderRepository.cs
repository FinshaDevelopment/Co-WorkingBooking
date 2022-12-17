using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
