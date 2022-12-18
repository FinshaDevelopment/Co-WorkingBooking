using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.Seats;
using CoWorkingBooking.Service.Exceptions;
using CoWorkingBooking.Service.Extensions;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Services.CoWorkings
{
    public class SeatService : ISeatService
    {
        private readonly IUnitOfWork unitOfWork;

        public SeatService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<SeatForViewDTO> CreateAsync(SeatForCreationDTO seatForCreationDTO)
        {
            var seat = await unitOfWork.Seats.CreateAsync(seatForCreationDTO.Adapt<Seat>());
            await unitOfWork.SaveChangesAsync();
            return seat.Adapt<SeatForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var isDeleted = await unitOfWork.Seats.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return isDeleted ? true : throw new CoWorkingException(404, "Seat not found");
        }

        public async ValueTask<IEnumerable<SeatForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            var seat = unitOfWork.Seats.GetAll(includes: new string[] { "CoWorking" }, isTracking: false);

            return (await seat.ToPagedList(@params).ToListAsync()).Adapt<IEnumerable<SeatForViewDTO>>();
        }

        public async ValueTask<SeatForViewDTO> GetAsync(Expression<Func<Seat, bool>> expression)
        {
            var seat = (await unitOfWork.Seats.GetAsync(expression, new string[] { "CoWorking" })).Adapt<SeatForViewDTO>();
            return seat ?? throw new CoWorkingException(404, "Seat not foud");
        }

        public async ValueTask<SeatForViewDTO> UpdateAsync(int id, SeatForCreationDTO seatForCreationDTO)
        {
            var seat = await unitOfWork.CoWorkings.GetAsync(o => o.Id == id);

            if (seatForCreationDTO is null)
                throw new CoWorkingException(404, "Seat not found");

            seat.UpdatedAt = DateTime.UtcNow;
            seat = unitOfWork.CoWorkings.Update(seatForCreationDTO.Adapt(seat));


            await unitOfWork.SaveChangesAsync();

            return seat.Adapt<SeatForViewDTO>();
        }
    }
}
