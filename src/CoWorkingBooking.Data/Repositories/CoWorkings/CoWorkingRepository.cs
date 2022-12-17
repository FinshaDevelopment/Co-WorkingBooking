namespace CoWorkingBooking.Data.Repositories.CoWorkings
{
    public class CoWorkingRepository : GenericRepository<CoWorking>, ISeatRepository
    {
        public CoWorkingRepository(CoWorkingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
