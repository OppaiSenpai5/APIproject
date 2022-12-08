using Models.Entities;
using Persistence;
using Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
