using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using Persistence.Seed;

namespace Persistence.Configurations
{
    public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasData(Seeder.AnimeSeed());
        }
    }
}
