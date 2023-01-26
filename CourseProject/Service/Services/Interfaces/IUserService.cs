namespace Service.Services.Interfaces
{
    using Models.Dtos;
    using Models.Entities;

    public interface IUserService : IService<User>
    {
        IEnumerable<UserDto> GetAllDto();
        UserDto GetDto(Guid id);
        void AddFavouriteAnime(Guid id);
    }
}
