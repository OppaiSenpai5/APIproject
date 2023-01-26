﻿namespace Api.Controllers
{
    using Service.Services.Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("add_favourite_anime")]
        [Authorize]
        public IActionResult AddFavouriteAnime([FromHeader] Guid id)
        {
            this.service.AddFavouriteAnime(id);
            return Ok();
        }
    }
}
