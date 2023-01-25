using Models.Dtos;
using Models.Entities;

namespace Service.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        IEnumerable<UserDto> GetAllDto();
        UserDto GetDto(Guid id);
        void AddFavouriteAnime(Guid id);
    }
}
