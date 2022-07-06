using BookingHotel.DTO;
using BookingHotel.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AuthDto result = await authService.Register(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { token = result.Token, expiresOn = result.ExpiresOn, UserRole = result.Roles });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(TokenRequestDto model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AuthDto result = await authService.Login(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { token = result.Token, expiresOn = result.ExpiresOn, UserRole = result.Roles, Email = result.Email });
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("addRole")]
        public async Task<IActionResult> AddRole(AddRoleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string result = await authService.AddRole(model);
            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }

            return Ok(model);
        }
    }
}
