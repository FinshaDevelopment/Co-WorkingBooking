using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Data.Repositories;
using CoWorkingBooking.Service.DTOs.Users;
using CoWorkingBooking.Service.Interfaces.Users;
using CoWorkingBooking.Service.Services.Users;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoWorkingBooking.Test.Unit.Services.Users
{
    public partial class UserServiceTest
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CoWorkingDbContext coWorkingDbContext;
        private readonly IUserService userService;

        public UserServiceTest()
        {
            var options = new DbContextOptionsBuilder<CoWorkingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            coWorkingDbContext = new CoWorkingDbContext(options);
            this.unitOfWork = new UnitOfWork(coWorkingDbContext);
            userService = new UserService(unitOfWork);
        }

        private UserForCreationDTO CreateRandomUser(UserForCreationDTO userForCreationDto)
        {
            userForCreationDto.FirstName = Faker.Name.First();
            userForCreationDto.LastName = Faker.Name.Last();
            userForCreationDto.Username = Faker.Name.Middle();
            userForCreationDto.Password = Faker.Lorem.GetFirstWord() + Faker.RandomNumber.Next();
            userForCreationDto.Email = Faker.Internet.Email();
            return userForCreationDto;
        }

    }
}
