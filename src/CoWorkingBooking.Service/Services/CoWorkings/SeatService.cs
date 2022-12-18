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
using System.Linq;
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
            var coWorking = await unitOfWork.CoWorkings.GetAsync(c => c.Id == seatForCreationDTO.CoworkingId);

            if (coWorking is null)
                throw new CoWorkingException(404,"coWorking not found");

            coWorking.NumberOfSeats++;
            
            unitOfWork.CoWorkings.Update(coWorking);
            var seat = await unitOfWork.Seats.CreateAsync(seatForCreationDTO.Adapt<Seat>());

            await unitOfWork.SaveChangesAsync();
            return seat.Adapt<SeatForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var seat = await unitOfWork.Seats.GetAsync(c => c.Id == id);

            if (seat is null)
                throw new CoWorkingException(404,"Seat not found");
            
            var coWorking = await unitOfWork.CoWorkings.GetAsync(c => c.Id == seat.CoworkingId);

            coWorking.NumberOfSeats--;
            
            unitOfWork.CoWorkings.Update(coWorking);

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

        public IEnumerable<SeatForViewDTO> SortByBookedTime()
        {
            var seats = unitOfWork.Seats.GetAll(includes: new string[] { "CoWorking" }, isTracking: false).Adapt<IEnumerable<SeatForViewDTO>>();

            return seats.Where(s => !s.IsBooked).Concat(seats.Where(s => s.IsBooked));
            
        }

        public async ValueTask<SeatForViewDTO> UpdateAsync(long id, SeatForCreationDTO seatForCreationDTO)
        {
            var coWorking = await unitOfWork.CoWorkings.GetAsync(c => c.Id == seatForCreationDTO.CoworkingId);

            
            var seat = await unitOfWork.Seats.GetAsync(o => o.Id == id);

            if (seat is null)
                throw new CoWorkingException(404, "Seat not found");

            if (coWorking is null)
                throw new CoWorkingException(404, "coWorking not found");

            if (seat.CoworkingId != seatForCreationDTO.CoworkingId)
                coWorking.NumberOfSeats--;

            seat.UpdatedAt = DateTime.UtcNow;

            unitOfWork.CoWorkings.Update(coWorking);
            seat = unitOfWork.Seats.Update(seatForCreationDTO.Adapt(seat));

            await unitOfWork.SaveChangesAsync();

            return seat.Adapt<SeatForViewDTO>();
        }
    }
}
