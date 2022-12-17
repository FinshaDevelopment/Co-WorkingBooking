using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<CoWorking> CoWorkings { get; }
        IGenericRepository<Branch> Branches { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Seat> Seats { get; }
        IGenericRepository<Payment> Payments { get; }

        ValueTask SaveChangesAsync();
    }
}
