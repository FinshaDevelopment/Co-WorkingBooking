using CoWorkingBooking.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.IRepositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
