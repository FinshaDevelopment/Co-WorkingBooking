using CoWorkingBooking.Data.Contexts;
using CoWorkingBooking.Data.IRepositories;
using CoWorkingBooking.Data.Repositories;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using CoWorkingBooking.Service.Services.CoWorkings;
using CoWorkingBooking.Service.Services.OrderService;
using Microsoft.EntityFrameworkCore;

namespace CoWorkingBooking.Test.Unit.Services.CoWorking
{
    public partial class CoWorkingServiceTest
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CoWorkingDbContext coWorkingDbContext;
        private readonly ICoWorkingService coWorkingService;
        private readonly IBranchService branchService;

        public CoWorkingServiceTest()
        {
            var options = new DbContextOptionsBuilder<CoWorkingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            coWorkingDbContext = new CoWorkingDbContext(options);
            this.unitOfWork = new UnitOfWork(coWorkingDbContext);

            coWorkingDbContext = new CoWorkingDbContext(options);
            unitOfWork = new UnitOfWork(coWorkingDbContext);
            coWorkingService = new CoWorkingService(unitOfWork);
            branchService = new BranchService(unitOfWork);
        }

        private CoWorkingForCreationDTO CreateRandomCoWorking(CoWorkingForCreationDTO coWorkingForCreationDTO)
        {
            coWorkingForCreationDTO.Floor = (byte)Faker.RandomNumber.Next(0, 30);
            coWorkingForCreationDTO.NumberOfSeats = (byte)Faker.RandomNumber.Next(0, 15);
            coWorkingForCreationDTO.Price = (decimal)Faker.RandomNumber.Next();

            return coWorkingForCreationDTO;
        }

        private BranchForCreationDTO CreateRandomBranch(BranchForCreationDTO branchForCreationDTO)
        {
            branchForCreationDTO.Name = Faker.Name.Middle();
            return branchForCreationDTO;
        }
    }
}
