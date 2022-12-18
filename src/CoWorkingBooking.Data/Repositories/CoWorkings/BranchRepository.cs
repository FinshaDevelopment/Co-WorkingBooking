using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories.CoWorkings;
using CoWorkingBooking.Domain.Entities.CoWorkings;

namespace CoWorkingBooking.Data.Repositories.CoWorkings
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
