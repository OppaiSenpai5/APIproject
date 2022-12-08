using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAnimeService : IService<Anime>
    {
        IEnumerable<AnimeDto> GetAllDto();
        AnimeDto GetDtoById(Guid id);
        Anime Create(AnimeDto animeDto);
        void Update(Guid id, AnimeDto animeDto);
    }
}
