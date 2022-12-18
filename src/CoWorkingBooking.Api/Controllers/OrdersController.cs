using CoWorkingBooking.Api.Helpers;
using CoWorkingBooking.Domain.Configurations;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Enums;
using CoWorkingBooking.Service.DTOs.Orders;
using CoWorkingBooking.Service.Interfaces.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }


        /// <summary>
        /// Create order
        /// </summary>
        [HttpPost, Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<Order>> CreateAsync(OrderForCreationDTO dto) =>
            Ok(await orderService.CreateAsync(dto));

        /// <summary>
        /// Delete order by id (admin)
        /// </summary>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
            Ok(await orderService.DeleteAsync(id));

        /// <summary>
        /// Get all orders
        /// </summary>
        [HttpGet, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<ActionResult<IEnumerable<Order>>> GetAllAsync(
            [FromQuery] PaginationParams @params) =>
                Ok(await orderService.GetAllAsync(@params));

        /// <summary>
        /// Get definition of order
        /// </summary>
        [HttpGet("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<Order>> GetAsync([FromRoute] long id) =>
            Ok(await orderService.GetAsync(order => order.Id == id));

        /// <summary>
        /// Update order
        /// </summary>
        [HttpPut("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<Order>> UpdateAsync(
            [FromRoute] long id, [FromBody] OrderForCreationDTO dto) =>
                Ok(await orderService.UpdateAsync(id, dto));
    }
}
