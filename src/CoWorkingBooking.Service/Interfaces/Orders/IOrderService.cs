using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Interfaces.Orders
{
    public interface IOrderService
    {
        ValueTask<OrderForViewDTO> CreateAsync(OrderForCreationDTO orderForCreationDTO);

        ValueTask<OrderForViewDTO> UpdateAsync(int id, OrderForCreationDTO orderForCreationDTO);

        ValueTask<bool> DeleteAsync(long id);

        ValueTask<IEnumerable<OrderForViewDTO>> GetAllAsync(
            PaginationParams @params );

        ValueTask<OrderForViewDTO> GetAsync(Expression<Func<Order, bool>> expression);
    }
}
