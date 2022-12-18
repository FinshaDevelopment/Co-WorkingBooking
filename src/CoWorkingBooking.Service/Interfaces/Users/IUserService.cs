using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Domain.Enums;
using CoWorkingBooking.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Interfaces.Users
{
    public interface IUserService
    {
        ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO);

        ValueTask<UserForViewDTO> UpdateAsync(string password, UserForUpdateDTO userForUpdateDTO);

        ValueTask<bool> DeleteAsync(long id);

        ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<User, bool>> expression = null);

        ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression);

        ValueTask<bool> ChangeRoleAsync(int id, UserRole userRole);

        ValueTask<bool> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO);
        ValueTask<UserForViewDTO> GetInfoAsync();
    }
}
