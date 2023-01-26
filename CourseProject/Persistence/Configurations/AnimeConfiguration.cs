namespace Persistence.Configurations
{
    using Models.Entities;
    using Persistence.Seed;
    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasData(Seeder.AnimeSeed());
        }
    }
}
