using Models.Entities;
using Service.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class UserAnimeService :
        Service<UserAnime, IUserAnimeRepository>, IUserAnimeService, IService<UserAnime>
    {
        public UserAnimeService(IUserAnimeRepository repository) : base(repository)
        {
        }
    }
}
