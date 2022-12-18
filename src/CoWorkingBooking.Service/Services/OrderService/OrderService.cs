using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Service.DTOs.Orders;
using CoWorkingBooking.Service.DTOs.Users;
using CoWorkingBooking.Service.Exceptions;
using CoWorkingBooking.Service.Extensions;
using CoWorkingBooking.Service.Helpers;
using CoWorkingBooking.Service.Interfaces.Orders;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace orderBooking.Service.Services.Orderervice
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<OrderForViewDTO> CreateAsync(OrderForCreationDTO orderForCreationDTO)
        {
            if (await unitOfWork.Users.GetAsync(u => u.Id == HttpContextHelper.UserId) is null)
                throw new CoWorkingException(404, "User not found");

            var order = await unitOfWork.Orders.CreateAsync(orderForCreationDTO.Adapt<Order>());
            await unitOfWork.SaveChangesAsync();
            return order.Adapt<OrderForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var isDeleted = await unitOfWork.Orders.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return isDeleted ? true : throw new CoWorkingException(404, "Order not found");
        }

        public async ValueTask<IEnumerable<OrderForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            var Order = unitOfWork.Orders.GetAll(includes: new string[] { "Order", "Seat" },isTracking: false);

            return (await Order.ToPagedList(@params).ToListAsync()).Adapt<IEnumerable<OrderForViewDTO>>();
        }

        public async ValueTask<OrderForViewDTO> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var order = (await unitOfWork.Orders.GetAsync(expression, new string[] { "Order", "Seat" })).Adapt<OrderForViewDTO>();
            return order ?? throw new CoWorkingException(404, "Order not foud");
        }

        public async ValueTask<OrderForViewDTO> UpdateAsync(int id, OrderForCreationDTO orderForCreationDTO)
        {
            var order = await unitOfWork.Orders.GetAsync(o => o.Id == id);

            if(order.UserId != HttpContextHelper.UserId)
                throw new CoWorkingException(404, "User not found");

            order.UpdatedAt = DateTime.UtcNow;
            order = unitOfWork.Orders.Update(orderForCreationDTO.Adapt(order));


            await unitOfWork.SaveChangesAsync();

            return order.Adapt<OrderForViewDTO>();
        }
    }
}
