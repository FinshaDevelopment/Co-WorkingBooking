using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Interfaces.CoWorkings
{
    public interface ICoWorkingService
    {
        ValueTask<CoWorkingForViewDTO> CreateAsync(CoWorkingForCreationDTO coWorkingForCreationDTO);

        ValueTask<CoWorkingForViewDTO> UpdateAsync(long id, CoWorkingForCreationDTO coWorkingForCreationDTO);

        ValueTask<bool> DeleteAsync(long id);

        ValueTask<IEnumerable<CoWorkingForViewDTO>> GetAllAsync(
            PaginationParams @params = null);

        ValueTask<CoWorkingForViewDTO> GetAsync(Expression<Func<CoWorking, bool>> expression);
    }
}
