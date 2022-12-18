using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using CoWorkingBooking.Service.DTOs.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Interfaces.CoWorkings
{
    public interface ISeatService
    {
        ValueTask<SeatForViewDTO> CreateAsync(SeatForCreationDTO seatForCreationDTO);

        ValueTask<SeatForViewDTO> UpdateAsync(int id, SeatForCreationDTO seatForCreationDTO);

        ValueTask<bool> DeleteAsync(long id);

        ValueTask<IEnumerable<SeatForViewDTO>> GetAllAsync(
            PaginationParams @params = null);

        ValueTask<SeatForViewDTO> GetAsync(Expression<Func<Seat, bool>> expression);
    }
}
