using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.Branches;
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
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork unitOfWork;
        public BranchService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO)
        {
            var alreadyExistBranch = await unitOfWork.Branches.GetAsync(b => b.Name == branchForCreationDTO.Name);

            if (alreadyExistBranch is not null)
                throw new CoWorkingException(400,"Such branch already exist");
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
            var branch = unitOfWork.Branches.GetAll(isTracking: false);

            return (await branch.ToPagedList(@params).ToListAsync()).Adapt<IEnumerable<BranchForViewDTO>>();
        }

        public async ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression)
        {
            var branch = (await unitOfWork.Branches.GetAsync(expression)).Adapt<BranchForViewDTO>();
            return branch ?? throw new CoWorkingException(404, "Branch not foud");
        }

        public async ValueTask<BranchForViewDTO> UpdateAsync(int id, BranchForCreationDTO branchForCreationDTO)
        {
            var branch = await unitOfWork.Branches.GetAsync(o => o.Id == id);

            if (branch is null)
                throw new CoWorkingException(404,"Branch not found");

            var alreadyExist = await unitOfWork.Branches.GetAsync(b => b.Name == branchForCreationDTO.Name);

            if (alreadyExist is not null && alreadyExist.Id != id)
                throw new CoWorkingException(400, "Branch already exist");


            branch.UpdatedAt = DateTime.UtcNow;
            branch = unitOfWork.Branches.Update(branchForCreationDTO.Adapt(branch));


            await unitOfWork.SaveChangesAsync();

            return branch.Adapt<BranchForViewDTO>();
        }
    }
}