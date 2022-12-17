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
        ValueTask<Order> CreateAsync(OrderForCreationDTO orderForCreationDTO);

        ValueTask<Order> UpdateAsync(int id, OrderForCreationDTO orderForCreationDTO);

        ValueTask<bool> DeleteAsync(Expression<Func<Order, bool>> expression);

        ValueTask<IEnumerable<Order>> GetAllAsync(
            PaginationParams @params = null,
            Expression<Func<Order, bool>> expression = null);

        ValueTask<Order> GetAsync(Expression<Func<Order, bool>> expression);
    }
}
