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
    public class UserAnimeRepository : Repository<UserAnime>, IUserAnimeRepository, IRepository<UserAnime>
    {
        public UserAnimeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
