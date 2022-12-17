using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoWorkingDbContext dbContext;

        public UnitOfWork(CoWorkingDbContext dbContext)
        {
            this.dbContext = dbContext;
            Users = new GenericRepository<User>(dbContext);
            CoWorkings = new GenericRepository<CoWorking>(dbContext);
            Branches = new GenericRepository<Branch>(dbContext);
            Orders = new GenericRepository<Order>(dbContext);
            Seats = new GenericRepository<Seat>(dbContext);
            Payments = new GenericRepository<Payment>(dbContext);
        }

        public IGenericRepository<User> Users { get; }

        public IGenericRepository<CoWorking> CoWorkings { get; }

        public IGenericRepository<Branch> Branches { get; }

        public IGenericRepository<Order> Orders { get; }

        public IGenericRepository<Seat> Seats { get; }

        public IGenericRepository<Payment> Payments { get; }

        public async ValueTask SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
