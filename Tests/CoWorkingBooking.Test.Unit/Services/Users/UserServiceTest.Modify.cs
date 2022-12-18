using CoWorkingBooking.Service.DTOs.Users;
using FluentAssertions;
using Force.DeepCloner;
using Mapster;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.Users
{
    public partial class UserServiceTest
    {
        [Fact]
        public async ValueTask ShouldModifyById()
        {
            //given

            UserForCreationDTO randomUser = CreateRandomUser(new UserForCreationDTO());

            UserForCreationDTO inputUser = randomUser;

            UserForCreationDTO expectedUser = inputUser.DeepClone();

            // when

            var actualUser = await userService.CreateAsync(inputUser);

            inputUser.LastName = Faker.Name.Last();


            var updatedUser = await userService.UpdateAsync(inputUser.Password, inputUser.Adapt<UserForUpdateDTO>());
            // then
            actualUser.Should().NotBeNull();

            updatedUser.Should().NotBeNull();

            actualUser.Should().BeEquivalentTo(expectedUser);
        }
    }
}
