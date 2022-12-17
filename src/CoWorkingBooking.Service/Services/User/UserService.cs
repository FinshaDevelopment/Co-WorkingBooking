using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Data.Repositories;
using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Domain.Enums;
using CoWorkingBooking.Service.DTOs.Users;
using CoWorkingBooking.Service.Interfaces.User;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var user = await unitOfWork.Users.GetAsync(user => user.Id==id);

            if (user is null)
                throw new Exception("User don't exist");

            var result = await unitOfWork.Users.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return result;
        }

        public ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<UserForViewDTO> GetIdAsync(long id)
        {
            var user = await unitOfWork.Users.GetAsync(user=> user.Id==id);

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

   

        public async ValueTask<bool> UpdateAsync(long id, UserForUpdateDTO viewModel)
        {
            var user = await unitOfWork.Users.GetAsync(user => user.Id == id);

            if (user is null)
                throw new Exception("User doesn't exist");
            var existUserbyUsername = await unitOfWork.Users.GetByUsernameAsync(viewModel.Username);

            if (existUserbyUsername is not null && existUserbyUsername.Id != id)
                throw new Exception("Username exists");

            var existUserByPhoneNumber = await unitOfWork.Users.GetByPhoneNumberAsync(viewModel.PhoneNumber);

            if (existUserByPhoneNumber is not null && existUserByPhoneNumber.Id != id)
                throw new Exception("Phone number exists");
            
            var existUserEmail = await unitOfWork.Users.GetAsync(user => user.Email == viewModel.Email);

            if (existUserEmail is not null && existUserEmail.Id != id)
                throw new Exception("Email exists");


            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;

            unitOfWork.Users.Update(user);

            await   unitOfWork.SaveChangesAsync();

            return true;
        }
    } 
}
