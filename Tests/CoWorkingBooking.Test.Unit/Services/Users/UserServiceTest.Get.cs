using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Service.DTOs.Users;
using FluentAssertions;
using Force.DeepCloner;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.Users
{
    public partial class UserServiceTest
    {
        [Fact]
        public async ValueTask ShouldGetUserById()
        {
            // given
            UserForCreationDTO randomUser = CreateRandomUser(new UserForCreationDTO());
            UserForCreationDTO inputUser = randomUser;
            UserForCreationDTO expectedUser = inputUser.DeepClone();

            // when
            var actualUser = await userService.CreateAsync(inputUser);
            UserForViewDTO gotUser = await userService.GetAsync(u => u.Id == actualUser.Id);

            // then
            actualUser.Should().NotBeNull();
            gotUser.Should().NotBeNull();
            actualUser.Should().BeEquivalentTo(gotUser);
        }

        [Fact]
        public async ValueTask ShouldGetAllUsers()
        {
            // given



            int number = Faker.RandomNumber.Next(0, 30);

            UserForCreationDTO[] usersForCreation = new UserForCreationDTO[number];

            for (int i = 0; i < number; i++)
            {
                usersForCreation[i] = CreateRandomUser(new UserForCreationDTO());
            }


            // when
            UserForViewDTO[] createdUsers = new UserForViewDTO[number];

            for (int i = 0; i < number; i++)
            {
                createdUsers[i] = await userService.CreateAsync(usersForCreation[i]);
            }

            List<UserForViewDTO> viewedUsers = (await userService.GetAllAsync(new PaginationParams())).ToList();

            // then
            viewedUsers.Should().HaveCount(number);
        }
    }
}
