using BLL.DTO.Users.Login;
using BLL.Services;
using BLL.Services.Interfaces;
using Entities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class AuthController(IAuthService service) : AbstractBaseController<IAuthService>(service)
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            var result = await service.RegisterAsync(request);
            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                string token = await service.LoginAsync(request);
                return Ok(new { token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
