using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Service.DTOs.Users;
using CoWorkingBooking.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoWorkingBooking.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        /// <summary>
        /// Authentification
        /// </summary>
        [HttpPost("login")]
        public async ValueTask<IActionResult> Login(UserForLoginDTO dto)
        {
            var token = await authService.GenerateToken(dto.Username, dto.Password);
            return Ok(new
            {
                token
            });
        }

        [HttpPost("register")]
        public async ValueTask<ActionResult<User>> CreateAsync(UserForCreationDTO dto) =>
           Ok(await userService.CreateAsync(dto));
    }
}
