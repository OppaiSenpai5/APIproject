﻿using Models.Entities;
using Persistence;
using Service.Repositories.Interfaces;

namespace Service.Repositories
{
    public class UserAnimeRepository : Repository<UserAnime>, IUserAnimeRepository, IRepository<UserAnime>
    {
        public UserAnimeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
