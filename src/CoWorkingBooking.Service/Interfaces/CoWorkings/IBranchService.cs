using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.Branches;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Interfaces.CoWorkings
{
    public interface IBranchService
    {
        ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO);

        ValueTask<BranchForViewDTO> UpdateAsync(long id, BranchForCreationDTO branchForCreationDTO);

        ValueTask<bool> DeleteAsync(long id);

        ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync(
            PaginationParams @params = null);

        ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression);
    }
}
