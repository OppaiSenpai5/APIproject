using Models.Entities;
using Persistence;
using Service.Repositories.Interfaces;

namespace Service.Repositories
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository, IRepository<Anime>
    {
        public AnimeRepository(AppDbContext context) : base(context)
        {
        }

        public bool ExistsById(Guid id) => Get(id) != null;

        public bool ExistsByTitle(string title) =>
            this.dbSet.Any(anime => anime.Title == title);
    }
}
