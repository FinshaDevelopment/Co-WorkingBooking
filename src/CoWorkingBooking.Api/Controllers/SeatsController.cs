using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Service.DTOs.Branches;
using CoWorkingBooking.Service.DTOs.Seats;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {

        private readonly ISeatService service;

        public SeatsController(ISeatService service)
        {
            this.service = service;
        }


        /// <summary>
        /// create seat
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost()]
        public async ValueTask<IActionResult> CreateAsync([FromBody] SeatForCreationDTO dto)
            => Ok(await service.CreateAsync(dto));

        // <summary>
        /// get all seats
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet()]
        public async ValueTask<IActionResult> GetAllAsync([FromBody] PaginationParams @params)
            => Ok(await service.GetAllAsync(@params));

        // <summary>
        /// Get seat by id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await service.GetAsync(seat => seat.Id == id));

        // <summary>
        /// Delete seat by id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await service.DeleteAsync(id));

        // <summary>
        /// Update seat
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] SeatForCreationDTO dto)
            => Ok(await service.UpdateAsync(id, dto));

    }
}
