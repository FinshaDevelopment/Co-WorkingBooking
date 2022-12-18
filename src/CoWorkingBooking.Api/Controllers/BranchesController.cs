using CoWorkingBooking.Api.Helpers;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/branches")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService service;

        public BranchesController(IBranchService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Create branch
        /// </summary>
        [HttpPost, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> CreateAsync([FromBody] BranchForCreationDTO dto)
            => Ok(await service.CreateAsync(dto));

        /// <summary>
        /// Get all braanches
        /// </summary>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery]PaginationParams @params)
            => Ok(await service.GetAllAsync(@params));

        /// <summary>
        /// Get branch by id
        /// </summary>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await service.GetAsync(branch=> branch.Id==id));

        /// <summary>
        /// Delete branch by id
        /// </summary>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await service.DeleteAsync(id));

        /// <summary>
        /// Update branch
        /// </summary>
        [HttpPut("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id,[FromBody] BranchForCreationDTO dto)
            => Ok(await service.UpdateAsync(id, dto));

    }
}
