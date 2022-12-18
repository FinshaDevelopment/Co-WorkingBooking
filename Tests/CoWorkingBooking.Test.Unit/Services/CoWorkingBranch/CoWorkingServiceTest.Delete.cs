using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using FluentAssertions;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.CoWorkingBranch
{
    public partial class CoWorkingServiceTest
    {
        [Fact]
        public async ValueTask ShouldDeleteUserById()
        {
            // given

            CoWorkingForCreationDTO randomCoWorking = CreateRandomCoWorking(new CoWorkingForCreationDTO());

            BranchForCreationDTO randomBranch = CreateRandomBranch(new BranchForCreationDTO());
            // when

            var createdBranch = await branchService.CreateAsync(branchForCreationDTO: randomBranch);

            randomCoWorking.BranchId = createdBranch.Id;

            var createdCoWorking = await coWorkingService.CreateAsync(randomCoWorking);

            bool isDeletedBranch = await branchService.DeleteAsync(createdBranch.Id);

            bool isDeletedCoWorking = await coWorkingService.DeleteAsync(createdCoWorking.Id);
            // then

            isDeletedBranch.Should().BeTrue();
            isDeletedCoWorking.Should().BeTrue();

        }
    }
}
