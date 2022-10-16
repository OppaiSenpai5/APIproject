using CourseProject.Data;
using CourseProject.Data.Entities;
using CourseProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Service.Services
{
    public class AnimeService : BaseService<Anime>, IBaseService<Anime>
    {
        public AnimeService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
