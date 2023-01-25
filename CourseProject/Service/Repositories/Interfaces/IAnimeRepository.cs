using Models.Entities;

namespace Service.Repositories.Interfaces
{
    public interface IAnimeRepository : IRepository<Anime>
    {
        bool ExistsByTitle(string title);
    }
}
