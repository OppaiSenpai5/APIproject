using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginDto login)
        {
            return Ok(service.GenerateToken(login));
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterDto registration)
        {
            service.Register(registration);
            return Ok();
        }
    }
}
