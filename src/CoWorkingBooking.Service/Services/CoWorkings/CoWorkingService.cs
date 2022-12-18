using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using CoWorkingBooking.Service.Exceptions;
using CoWorkingBooking.Service.Extensions;
using CoWorkingBooking.Service.Helpers;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Services.OrderService
{
    public class CoWorkingService : ICoWorkingService
    {
        private readonly IUnitOfWork unitOfWork;

        public CoWorkingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<CoWorkingForViewDTO> CreateAsync(CoWorkingForCreationDTO coWorkingForCreationDTO)
        {
            var order = await unitOfWork.CoWorkings.CreateAsync(coWorkingForCreationDTO.Adapt<CoWorking>());
            await unitOfWork.SaveChangesAsync();
            return order.Adapt<CoWorkingForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var isDeleted = await unitOfWork.CoWorkings.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return isDeleted ? true : throw new CoWorkingException(404, "CoWorking not found");
        }

        public async ValueTask<IEnumerable<CoWorkingForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            var Order = unitOfWork.CoWorkings.GetAll(includes: new string[] { "Order", "Seat" }, isTracking: false);

            return (await Order.ToPagedList(@params).ToListAsync()).Adapt<IEnumerable<CoWorkingForViewDTO>>();
        }

        public async ValueTask<CoWorkingForViewDTO> GetAsync(Expression<Func<CoWorking, bool>> expression)
        {
            var order = (await unitOfWork.CoWorkings.GetAsync(expression, new string[] { "Order", "Seat" })).Adapt<CoWorkingForViewDTO>();
            return order ?? throw new CoWorkingException(404, "CoWorking not foud");
        }

        public async ValueTask<CoWorkingForViewDTO> UpdateAsync(int id, CoWorkingForCreationDTO coWorkingForCreationDTO)
        {
            var order = await unitOfWork.CoWorkings.GetAsync(o => o.Id == id);

            if (coWorkingForCreationDTO is null)

            order.UpdatedAt = DateTime.UtcNow;
            order = unitOfWork.CoWorkings.Update(coWorkingForCreationDTO.Adapt(order));


            await unitOfWork.SaveChangesAsync();

            return order.Adapt<CoWorkingForViewDTO>();
        }
    }
}
