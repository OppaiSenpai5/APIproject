using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Interfaces
{
    public interface IAnimeRepository : IRepository<Anime>
    {
        bool ExistsById(Guid id);
        bool ExistsByTitle(string title);
    }
}
