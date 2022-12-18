using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.Exceptions;
using CoWorkingBooking.Service.Extensions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Services.CoWorkings
{
    public class BranchService 
    {
        private readonly IUnitOfWork unitOfWork;
        public BranchService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO)
        {
            var branch = await unitOfWork.Branches.CreateAsync(branchForCreationDTO.Adapt<Branch>());
            await unitOfWork.SaveChangesAsync();
            return branch.Adapt<BranchForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var isDeleted = await unitOfWork.Branches.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return isDeleted ? true : throw new CoWorkingException(404, "Branch not found");
        }

        public async ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            var branch = unitOfWork.Branches.GetAll(includes: new string[] { "Order", "Seat" }, isTracking: false);

            return (await branch.ToPagedList(@params).ToListAsync()).Adapt<IEnumerable<BranchForViewDTO>>();
        }

        public async ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression)
        {
            var branch = (await unitOfWork.Branches.GetAsync(expression, new string[] { "Order", "Seat" })).Adapt<BranchForViewDTO>();
            return branch ?? throw new CoWorkingException(404, "Branch not foud");
        }

        public async ValueTask<BranchForViewDTO> UpdateAsync(int id, BranchForCreationDTO coWorkingForCreationDTO)
        {
            var branch = await unitOfWork.Branches.GetAsync(o => o.Id == id);

            if (coWorkingForCreationDTO is null)

                branch.UpdatedAt = DateTime.UtcNow;
            branch = unitOfWork.Branches.Update(coWorkingForCreationDTO.Adapt(branch));


            await unitOfWork.SaveChangesAsync();

            return branch.Adapt<BranchForViewDTO>();
        }
    }
}
