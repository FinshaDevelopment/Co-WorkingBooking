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
        /// <param name="dto">user create</param>
        /// <returns>Created user infortaions</returns>
        /// <response code="200">If user is created successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async ValueTask<ActionResult<User>> CreateAsync(UserForCreationDTO dto) =>
            Ok(await userService.CreateAsync(dto));

        /// <summary>
        /// Update role 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPatch("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> ChangeRoleAsync(int id, UserRole userRole)
            => Ok(await userService.ChangeRoleAsync(id, userRole));

        /// <summary>
        /// Delete user by id (admin)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if user deleted succesfully else false</returns>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
            Ok(await userService.DeleteAsync(id));

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="params">pagenation params</param>
        /// <returns> user collection </returns>
        [HttpGet, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<ActionResult<IEnumerable<User>>> GetAllAsync(
            [FromQuery] PaginationParams @params) =>
                Ok(await userService.GetAllAsync(@params));

        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("password"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<User>> ChangePasswordAsync(UserForChangePasswordDTO userForChangePassword) =>
            Ok(await userService.ChangePasswordAsync(userForChangePassword));

        /// <summary>
        /// Get user information
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>user</returns>
        /// <response code="400">if user data is not in the base</response>
        /// <response code="200">if user data have in database</response>
        [HttpGet("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<User>> GetAsync([FromRoute] long id) =>
            Ok(await userService.GetAsync(user => user.Id == id));

        /// <summary>
        /// Update user 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut, Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<User>> UpdateAsync(
            string password, [FromBody] UserForUpdateDTO dto) =>
                Ok(await userService.UpdateAsync(password, dto));

        /// <summary>
        /// Get self user info
        /// </summary>
        /// <returns>user</returns>
        [HttpGet("info"), Authorize]
        public async ValueTask<ActionResult<User>> GetInfoAsync()
            => Ok(await userService.GetInfoAsync());
    }
}
