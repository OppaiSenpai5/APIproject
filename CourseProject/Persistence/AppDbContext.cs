using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence.Configurations;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AnimeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserAnimeConfiguration());
        }
    }
}
