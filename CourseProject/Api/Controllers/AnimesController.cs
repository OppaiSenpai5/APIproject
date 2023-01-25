using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/v1/animes")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimeService service;

        public AnimesController(IAnimeService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(service.GetAllDto());
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(service.GetDtoById(id));
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query) =>
            Ok(this.service.Search(query));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] AnimeDto request)
        {
            var anime = service.Create(request);

            return CreatedAtAction(nameof(Get), new { id = anime.Id }, request);
        }

        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] AnimeDto request)
        {
            service.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            service.Delete(id);
            return NoContent();
        }

        [HttpGet("favourites")]
        public IActionResult GetFavouriteAnimes(Guid userId) =>
            Ok(this.service.UserFavourites(userId));
    }
}
