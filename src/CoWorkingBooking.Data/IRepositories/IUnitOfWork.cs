using CoWorkingBooking.Data.IRepositories.Users;
using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Data.IRepositories.Orders;
using CoWorkingBooking.Data.Repositories.CoWorkings;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Entities.Users;
using RaqamliAvlod.DataAccess.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        IPaymentRepository Payments { get; }

        ValueTask SaveChangesAsync();
    }
}
