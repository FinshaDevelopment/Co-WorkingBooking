using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Domain.Enums;
using CoWorkingBooking.Service.DTOs.Users;
using CoWorkingBooking.Service.Exceptions;
using CoWorkingBooking.Service.Extensions;
using CoWorkingBooking.Service.Helpers;
using CoWorkingBooking.Service.Interfaces.Users;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<bool> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            var user = await unitOfWork.Users.GetAsync(u => u.Id == HttpContextHelper.UserId);

            if (user == null)
                throw new CoWorkingException(404, "User not found");

            if (user.Password != oldPassword.Encrypt())
            {
                throw new CoWorkingException(400, "Password is Incorrect");
            }
            user.Password = newPassword.Encrypt();

            unitOfWork.Users.Update(user);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async ValueTask<bool> ChangeRoleAsync(int id, UserRole userRole)
        {
            var existUser = await unitOfWork.Users.GetAsync(u => u.Id == id);
            if (existUser == null)
                throw new CoWorkingException(404, "User not found");

            existUser.Role = userRole;

            unitOfWork.Users.Update(existUser);
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
            var alreadyExistUser = await unitOfWork.Users.GetAsync(u => u.Username == userForCreationDTO.Username);

            if (alreadyExistUser != null)
                throw new CoWorkingException(400, "User With Such Username Already Exist");

            userForCreationDTO.Password = userForCreationDTO.Password.Encrypt();

            var user = await unitOfWork.Users.CreateAsync(userForCreationDTO.Adapt<User>());
            user.CreatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return user.Adapt<UserForViewDTO>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var isDeleted = await unitOfWork.Users.DeleteAsync(id);
            if (!isDeleted)
                throw new CoWorkingException(404, "User not found");
            return true;
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params)
        {
            var users = unitOfWork.Users.GetAll();

            return (await users.ToPagedList(@params).ToListAsync()).Adapt<List<UserForViewDTO>>();
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            var users = unitOfWork.Users.GetAll(expression: expression, isTracking: false, includes: new string[] { "Address" });

            return (await users.ToPagedList(@params).ToListAsync()).Adapt<List<UserForViewDTO>>();
        }

        public async ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await unitOfWork.Users.GetAsync(expression);

            if (user is null)
                throw new CoWorkingException(404, "User not found");

            return user.Adapt<UserForViewDTO>();
        }

        public async ValueTask<UserForViewDTO> GetIdAsync(long id)
        {
            var user = await unitOfWork.Users.GetAsync(user => user.Id == id);

            if (user is null)
                throw new Exception("User not found");

            var userView = user.Adapt<UserForViewDTO>();

            return userView;
        }

        public async ValueTask<UserForViewDTO> GetUsernameAsync(string username)
        {
            var user = await unitOfWork.Users.GetByUsernameAsync(username);

            if (user is null)
                throw new Exception("User not found");

            var userView = user.Adapt<UserForViewDTO>();

            return userView;
        }




        public async ValueTask<UserForViewDTO> UpdateAsync(string login, string password, UserForUpdateDTO userForUpdateDTO)
        {
            var user = await unitOfWork.Users.GetAsync(u => u.Username == login && u.Password == password.Encrypt());

            if (user is null)
                throw new Exception("User doesn't exist");
            var alreadyExistUser = await unitOfWork.Users.GetByUsernameAsync(userForUpdateDTO.Username);

            if (alreadyExistUser is not null && alreadyExistUser.Id != user.Id)
                throw new Exception("Username exists");

            alreadyExistUser = await unitOfWork.Users.GetByPhoneNumberAsync(userForUpdateDTO.PhoneNumber);

            if (alreadyExistUser is not null && alreadyExistUser.Id != user.Id)
                throw new Exception("Phone number exists");

            alreadyExistUser = await unitOfWork.Users.GetAsync(user => user.Email == userForUpdateDTO.Email);

            if (alreadyExistUser is not null && alreadyExistUser.Id != user.Id)
                throw new Exception("Email exists");

            user.UpdatedAt= DateTime.UtcNow;

            user = unitOfWork.Users.Update(userForUpdateDTO.Adapt(user));

            await unitOfWork.SaveChangesAsync();

            return user.Adapt<UserForViewDTO>();
        }
    }
}
