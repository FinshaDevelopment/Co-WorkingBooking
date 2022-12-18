using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using CoWorkingBooking.Service.Services.CoWorkings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService service;

        public BranchesController(IBranchService service)
        {
            this.service = service;
        }


        /// <summary>
        /// create branch
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost()]
        public async ValueTask<IActionResult> CreateAsync([FromBody]BranchForCreationDTO dto)
            => Ok(await service.CreateAsync(dto));

        // <summary>
        /// get all braanches
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet()]
        public async ValueTask<IActionResult> GetAllAsync([FromBody]PaginationParams @params)
            => Ok(await service.GetAllAsync(@params));

        // <summary>
        /// Get branch by id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute]long id)
            => Ok(await service.GetAsync(branch=> branch.Id==id));

        // <summary>
        /// Delete branch by id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute]long id)
           => Ok(await service.DeleteAsync(id));

        // <summary>
        /// Update branch
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute]long id,[FromBody] BranchForCreationDTO dto)
            => Ok(await service.UpdateAsync(id, dto));

    }
}
