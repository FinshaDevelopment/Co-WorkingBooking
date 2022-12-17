using CoWorkingBooking.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            return @params.PageIndex > 0 && @params.PageSize >= 0
                ? source.Take(((@params.PageIndex - 1) * @params.PageSize)..@params.PageSize)
                : source;
        }
    }
}
