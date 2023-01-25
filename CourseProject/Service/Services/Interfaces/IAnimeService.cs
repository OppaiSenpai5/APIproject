using Models.Dtos;
using Models.Entities;

namespace Service.Services.Interfaces
{
    public interface IAnimeService : IService<Anime>
    {
        IEnumerable<AnimeDto> GetAllDto();
        AnimeDto GetDtoById(Guid id);
        Anime Create(AnimeDto animeDto);
        void Update(Guid id, AnimeDto animeDto);
        IEnumerable<AnimeDto> Search(string query);
        IEnumerable<AnimeDto> UserFavourites(Guid userId);
    }
}
