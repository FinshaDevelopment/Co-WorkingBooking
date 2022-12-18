using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using Faker;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.CoWorkingBranch
{
    public partial class CoWorkingServiceTest
    {
        [Fact]
        public async ValueTask ShouldGetCoWorking()
        {
            // given

            CoWorkingForCreationDTO randomCoWorking = CreateRandomCoWorking(new CoWorkingForCreationDTO());

            BranchForCreationDTO randomBranch = CreateRandomBranch(new BranchForCreationDTO());
            // when

            var createdBranch = await branchService.CreateAsync(randomBranch);

            randomCoWorking.BranchId = createdBranch.Id;

            var createdCoWorking = await coWorkingService.CreateAsync(randomCoWorking);

            var receivedCoWorking = await coWorkingService.GetAsync(c => c.Id == createdCoWorking.Id);

            // then

            createdBranch.Should().NotBeNull();
            createdCoWorking.Should().NotBeNull();
        }

        public async ValueTask ShouldGetAllCoWorkings()
        {
            // given

            CoWorkingForCreationDTO[] coWorkingForCreationDTOs = new CoWorkingForCreationDTO[Faker.RandomNumber.Next(1, 30)];

            // when

            for (int i = 0; i < coWorkingForCreationDTOs.Length; i++)
            {
                coWorkingForCreationDTOs[i] = CreateRandomCoWorking(new CoWorkingForCreationDTO());

                BranchForCreationDTO randomBranch = CreateRandomBranch(new BranchForCreationDTO());
                
                var createdBranch = await branchService.CreateAsync(randomBranch);

                coWorkingForCreationDTOs[i].BranchId = createdBranch.Id;

                await coWorkingService.CreateAsync(coWorkingForCreationDTOs[i]);
            }

            var receivedCoWorkings = await coWorkingService.GetAllAsync();

            // then

            receivedCoWorkings.Should().NotBeNull();
            receivedCoWorkings.Count().Should().Be(coWorkingForCreationDTOs.Length);
        }
    }
}
