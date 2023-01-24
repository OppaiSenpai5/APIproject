using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.service.GetAllDto());
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id) 
        {
            return Ok(this.service.GetDto(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddFavouriteAnime([FromBody] Guid id)
        {
            this.service.AddFavouriteAnime(id);
            return NoContent();
        }
    }
}
