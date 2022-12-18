using CoWorkingBooking.Api.Helpers;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Service.DTOs.Seats;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/seats")]
    [ApiController]
    public class SeatsController : ControllerBase
    {

        private readonly ISeatService service;

        public SeatsController(ISeatService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Create seat
        /// </summary>
        [HttpPost, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> CreateAsync([FromBody] SeatForCreationDTO dto)
            => Ok(await service.CreateAsync(dto));

        /// <summary>
        /// Get all seats
        /// </summary>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await service.GetAllAsync(@params));


        /// <summary>
        ///  Sorted Chairs starting from free till less most busy
        /// </summary>
        [HttpGet("sorted")]
        public IActionResult SortByBookedTime() =>
            Ok(service.SortByBookedTime());


        /// <summary>
        /// Get seat by id
        /// </summary>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await service.GetAsync(seat => seat.Id == id));

        /// <summary>
        /// Delete seat by id
        /// </summary>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await service.DeleteAsync(id));

        /// <summary>
        /// Update seat
        /// </summary>
        [HttpPut("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] SeatForCreationDTO dto)
            => Ok(await service.UpdateAsync(id, dto));
    }
}
