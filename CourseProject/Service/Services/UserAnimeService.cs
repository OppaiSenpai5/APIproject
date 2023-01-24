using Models.Entities;
using Service.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
