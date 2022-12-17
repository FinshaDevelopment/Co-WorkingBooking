using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.Repositories.CoWorkings
{
    public class CoWorkingRepository : GenericRepository<CoWorking>, ISeatRepository
    {
        public CoWorkingRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
