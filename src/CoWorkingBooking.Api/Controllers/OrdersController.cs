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
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<Order>> CreateAsync(OrderForCreationDTO dto) =>
            Ok(await orderService.CreateAsync(dto));

        /// <summary>
        /// Delete order by id (admin)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if order deleted succesfully else false</returns>
        [HttpDelete("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
            Ok(await orderService.DeleteAsync(id));

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <param name="params">pagenation params</param>
        /// <returns> order collection </returns>
        [HttpGet, Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<ActionResult<IEnumerable<Order>>> GetAllAsync(
            [FromQuery] PaginationParams @params) =>
                Ok(await orderService.GetAllAsync(@params));

        /// <summary>
        /// Get definition of order
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns>user</returns>
        /// <response code="400">if order data is not in the base</response>
        /// <response code="200">if order data have in database</response>
        [HttpGet("{id}"), Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<Order>> GetAsync([FromRoute] long id) =>
            Ok(await orderService.GetAsync(order => order.Id == id));

        /// <summary>
        /// Update order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut, Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<ActionResult<Order>> UpdateAsync(
            int id, [FromBody] OrderForCreationDTO dto) =>
                Ok(await orderService.UpdateAsync(id, dto));
    }
}
