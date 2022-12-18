using CoWorkingBooking.Service.DTOs.Users;
using Force.DeepCloner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CoWorkingBooking.Test.Unit.Services.Users
{
    public partial class UserServiceTest
    {
        [Fact]
        public async ValueTask ShouldCreateUser()
        {
            // given
            UserForCreationDTO randomUser = CreateRandomUser(new UserForCreationDTO());
            UserForCreationDTO inputUser = randomUser;

            // when

            var actualUser = await userService.CreateAsync(inputUser);

            // then
            actualUser.Username.Should().BeEquivalentTo(inputUser.Username);
            actualUser.FirstName.Should().BeEquivalentTo(inputUser.FirstName);
            actualUser.LastName.Should().BeEquivalentTo(inputUser.LastName);
        }
    }
}
