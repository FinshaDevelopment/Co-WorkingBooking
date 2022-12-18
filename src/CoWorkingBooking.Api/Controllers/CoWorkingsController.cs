<<<<<<< HEAD
﻿using CoWorkingBooking.Api.Helpers;
using CoWorkingBooking.Domain.Configurations;
=======
﻿using CoWorkingBooking.Domain.Configurations;
>>>>>>> abacc5a62d6de41c7b9b51723cb90e404cf6b55a
using CoWorkingBooking.Service.DTOs.CoWorkings;
using CoWorkingBooking.Service.Interfaces.CoWorkings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/coWorkings")]
    [ApiController]
    public class CoWorkingsController : ControllerBase
    {
        private readonly ICoWorkingService service;

        public CoWorkingsController(ICoWorkingService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Create Co-Working
        /// </summary>
        [HttpPost, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> CreateAsync([FromBody] CoWorkingForCreationDTO dto)
            => Ok(await service.CreateAsync(dto));

        /// <summary>
        /// Get all Co-Workinges
        /// </summary>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await service.GetAllAsync(@params));

        /// <summary>
        /// Get Co-Working by id
        /// </summary>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await service.GetAsync(coWorking => coWorking.Id == id));

        /// <summary>
        /// Delete Co-Working by id
        /// </summary>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] long id)
           => Ok(await service.DeleteAsync(id));

        /// <summary>
        /// Update Co-Working
        /// </summary>
        [HttpPut("{id}"), Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] CoWorkingForCreationDTO dto)
            => Ok(await service.UpdateAsync(id, dto));
    }
}
