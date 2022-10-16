using CourseProject.Data.Entities;
using CourseProject.Service.Interfaces;
using CourseProject.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [ApiController]
    [Route("animes")]
    public class AnimesController : ControllerBase
    {
        private readonly IBaseService<Anime> animeService;

        public AnimesController(IBaseService<Anime> animeService) => this.animeService = animeService;

        [HttpGet]
        public ActionResult<IEnumerable<Anime>> Get() => Ok(animeService.GetAll().ToArray());

        [HttpGet("{id}")]
        public ActionResult<Anime> Get([FromRoute] Guid id) => Ok(animeService.Get(id));

        [HttpPost]
        public ActionResult<Anime> Post([FromBody] Anime anime)
        {
            this.animeService.Create(anime);

            return CreatedAtAction(nameof(Get), new { id = anime.Id }, anime);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid? id, [FromBody] Anime anime)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            anime.Id = id.Value;

            animeService.Update(anime);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var anime = this.animeService.Get(id.Value);
            if (anime is null)
            {
                return NotFound();
            }

            this.animeService.Delete(anime);
            return NoContent();
        }
    }
}
