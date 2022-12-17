namespace CoWorkingBooking.Data.Repositories.CoWorkings
{
    public class CoWorkingRepository : GenericRepository<CoWorking>, ICoWorkingRepository
    {
        public CoWorkingRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
