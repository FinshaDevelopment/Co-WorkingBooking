using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using CoWorkingBooking.Service.Exceptions;
using CoWorkingBooking.Service.Extensions;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            if (await unitOfWork.Branches.GetAsync(b => b.Id == coWorkingForCreationDTO.BranchId) is null)
                throw new CoWorkingException(404, "Branch not found");
            var coWorking = await unitOfWork.CoWorkings.CreateAsync(coWorkingForCreationDTO.Adapt<CoWorking>());


            await unitOfWork.SaveChangesAsync();
            return coWorking.Adapt<CoWorkingForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var isDeleted = await unitOfWork.CoWorkings.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return isDeleted ? true : throw new CoWorkingException(404, "CoWorking not found");
        }

        public async ValueTask<IEnumerable<CoWorkingForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            var coWorking = unitOfWork.CoWorkings.GetAll(includes: new string[] { "Branch" }, isTracking: false);

            return (await coWorking.ToPagedList(@params).ToListAsync()).Adapt<IEnumerable<CoWorkingForViewDTO>>();
        }

        public async ValueTask<CoWorkingForViewDTO> GetAsync(Expression<Func<CoWorking, bool>> expression)
        {
            var coWorking = (await unitOfWork.CoWorkings.GetAsync(expression, new string[] { "Branch" })).Adapt<CoWorkingForViewDTO>();
            return coWorking ?? throw new CoWorkingException(404, "CoWorking not foud");
        }

        public async ValueTask<CoWorkingForViewDTO> UpdateAsync(long id, CoWorkingForCreationDTO coWorkingForCreationDTO)
        {
            var coWorking = await unitOfWork.CoWorkings.GetAsync(o => o.Id == id);

            if (coWorkingForCreationDTO is null)

                coWorking.UpdatedAt = DateTime.UtcNow;
            coWorking = unitOfWork.CoWorkings.Update(coWorkingForCreationDTO.Adapt(coWorking));


            await unitOfWork.SaveChangesAsync();

            return coWorking.Adapt<CoWorkingForViewDTO>();
        }
    }
}
