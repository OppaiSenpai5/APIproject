namespace Service.Services
{
    using Models.Entities;
    using Service.Repositories.Interfaces;
    using Service.Services.Interfaces;

    public class UserAnimeService :
        Service<UserAnime, IUserAnimeRepository>, IUserAnimeService, IService<UserAnime>
    {
        public UserAnimeService(IUserAnimeRepository repository) : base(repository)
        {
        }
    }
}
