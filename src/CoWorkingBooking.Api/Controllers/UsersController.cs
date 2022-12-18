using CoWorkingBooking.Api.Helpers;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Domain.Enums;
using CoWorkingBooking.Service.DTOs.Users;
using CoWorkingBooking.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        [HttpPost]
        public async ValueTask<ActionResult<User>> CreateAsync(UserForCreationDTO dto) =>
            Ok(await userService.CreateAsync(dto));

        /// <summary>
        /// Update role 
        /// </summary>
        [HttpPatch("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> ChangeRoleAsync(int id, UserRole userRole)
            => Ok(await userService.ChangeRoleAsync(id, userRole));

        /// <summary>
        /// Delete user by id (admin)
        /// </summary>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
            Ok(await userService.DeleteAsync(id));

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<ActionResult<IEnumerable<User>>> GetAllAsync(
            [FromQuery] PaginationParams @params) =>
                Ok(await userService.GetAllAsync(@params));

        /// <summary>
        /// Update password
        /// </summary>
        [HttpPatch("password"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<User>> ChangePasswordAsync(UserForChangePasswordDTO userForChangePassword) =>
            Ok(await userService.ChangePasswordAsync(userForChangePassword));

        /// <summary>
        /// Get user information
        /// </summary>
        [HttpGet("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<User>> GetAsync([FromRoute] long id) =>
            Ok(await userService.GetAsync(user => user.Id == id));

        /// <summary>
        /// Update user 
        /// </summary>
        [HttpPut, Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<User>> UpdateAsync(
            string password, [FromBody] UserForUpdateDTO dto) =>
                Ok(await userService.UpdateAsync(password, dto));

        /// <summary>
        /// Get self user info
        /// </summary>
        [HttpGet("info"), Authorize]
        public async ValueTask<ActionResult<User>> GetInfoAsync()
            => Ok(await userService.GetInfoAsync());
    }
}
