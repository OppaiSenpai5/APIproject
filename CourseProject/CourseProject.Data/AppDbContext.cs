using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject;
using CourseProject.Data.Entities;
using CourseProject.Data.DbConfigurations;

namespace CourseProject.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Anime> Animes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AnimeConfiguration());
        }
    }
}
