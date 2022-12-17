using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWorkingBooking.Data.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        ValueTask<T> CreateAsync(T entity);
        T Update(T entity);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null,
            string[] includes = null,
            bool isTracking = true);
    }
}
