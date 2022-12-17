using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Domain.Entities.CoWorkings;

namespace CoWorkingBooking.Data.Repositories.CoWorkings
{
    public class CoWorkingRepository : GenericRepository<CoWorking>, ICoWorkingRepository
    {
        public CoWorkingRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
