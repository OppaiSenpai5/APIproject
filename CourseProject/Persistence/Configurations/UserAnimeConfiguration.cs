namespace Persistence.Configurations
{
    using Models.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserAnimeConfiguration : IEntityTypeConfiguration<UserAnime>
    {
        public void Configure(EntityTypeBuilder<UserAnime> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.UserAnimes)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Anime)
                .WithMany(y => y.UserAnimes)
                .HasForeignKey(x => x.AnimeId);
        }
    }
}
