using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Domain.Entities.CoWorkings;

namespace CoWorkingBooking.Data.Repositories.CoWorkings
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        public SeatRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
