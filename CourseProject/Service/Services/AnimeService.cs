using AutoMapper;
using Service.Exceptions;
using Models.Dtos;
using Models.Entities;
using Service.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AnimeService : 
        Service<Anime, IAnimeRepository>, IAnimeService, IService<Anime>
    {
        private readonly IMapper mapper;

        public AnimeService(IAnimeRepository repository, IMapper mapper)
            : base(repository)
        {
            this.mapper = mapper;
        }

        public Anime Create(AnimeDto animeDto)
        {
            if (this.repository.ExistsByTitle(animeDto.Title))
            {
                throw new BadRequestException(
                    new { errorMessage = "An anime with that name already exists."});
            }

            Anime anime = mapper.Map<Anime>(animeDto);
            Create(anime);
            return anime;
        }

        public IEnumerable<AnimeDto> GetAllDto() => 
            GetAll().Select(a => mapper.Map<AnimeDto>(a)).ToList();

        public AnimeDto GetDtoById(Guid id) => 
            mapper.Map<AnimeDto>(GetById(id));

        public void Update(Guid id, AnimeDto animeDto)
        {
            var anime = mapper.Map<Anime>(animeDto) with { Id = id };
            Update(anime);
        }
    }
}
