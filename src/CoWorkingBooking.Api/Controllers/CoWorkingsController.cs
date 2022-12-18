using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.CoWorkings;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoWorkingsController : ControllerBase
    {
        private readonly ICoWorkingService service;

        public CoWorkingsController(ICoWorkingService service)
        {
            this.service = service;
        }


        /// <summary>
        /// create CoWorking
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost()]
        public async ValueTask<IActionResult> CreateAsync([FromBody] CoWorkingForCreationDTO dto)
            => Ok(await service.CreateAsync(dto));

        // <summary>
        /// Get all CoWorkinges
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet()]
        public async ValueTask<IActionResult> GetAllAsync([FromBody] PaginationParams @params)
            => Ok(await service.GetAllAsync(@params));

        // <summary>
        /// Get CoWorking by id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute]long id)
            => Ok(await service.GetAsync(coWorking => coWorking.Id == id));

        // <summary>
        /// Delete CoWorking by id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await service.DeleteAsync(id));

        // <summary>
        /// Update CoWorking
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] CoWorkingForCreationDTO dto)
            => Ok(await service.UpdateAsync(id, dto));
    }
}
