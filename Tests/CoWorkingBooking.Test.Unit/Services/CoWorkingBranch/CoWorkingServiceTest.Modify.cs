using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using FluentAssertions;
using Mapster;
using System.Threading.Tasks;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.CoWorkingBranch
{
    public partial class CoWorkingServiceTest
    {
        [Fact]
        public async ValueTask ShouldModifyCoWorkingById() 
        {
            // given

            CoWorkingForCreationDTO randomCoWorking = CreateRandomCoWorking(new CoWorkingForCreationDTO());

            BranchForCreationDTO randomBranch = CreateRandomBranch(new BranchForCreationDTO());
            // when

            var createdBranch = await branchService.CreateAsync(randomBranch);

            randomCoWorking.BranchId = createdBranch.Id;

            var createdCoWorking = await coWorkingService.CreateAsync(randomCoWorking);

            createdCoWorking.Price = Faker.RandomNumber.Next();

            var updatedCoWorking = await coWorkingService.UpdateAsync(createdCoWorking.Id,createdCoWorking.Adapt<CoWorkingForCreationDTO>());
            // then

            createdBranch.Should().NotBeNull();
            createdCoWorking.Should().NotBeNull();
            updatedCoWorking.Should().NotBeNull();
            updatedCoWorking.Price.Should().NotBe(createdCoWorking.Price);

            createdCoWorking.Floor.Should().Be(randomCoWorking.Floor);
        }
    }
}
