using CoWorkingBooking.Service.DTOs.Users;
using FluentAssertions;
using Force.DeepCloner;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.Users
{
    public partial class UserServiceTest
    {
        [Fact]
        public async ValueTask ShoulDeleteUserById()
        {
            //given

            UserForCreationDTO randomUser = CreateRandomUser(new UserForCreationDTO());

            UserForCreationDTO inputUser = randomUser;

            UserForCreationDTO expectedUser = inputUser.DeepClone();

            // when

            var actualUser = await userService.CreateAsync(inputUser);

            bool isDeleted = await userService.DeleteAsync(actualUser.Id);

            // then
            actualUser.Should().NotBeNull();

            actualUser.Username.Should().BeEquivalentTo(expectedUser.Username);

            isDeleted.Should().Be(true);

            (await userService.GetAsync(u => u.Id == actualUser.Id)).Should().BeNull();
        }

    }
}
