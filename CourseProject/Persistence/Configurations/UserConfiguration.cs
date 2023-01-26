namespace Persistence.Configurations
{
    using Models.Entities;
    using Persistence.Seed;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Role).HasColumnType("nvarchar(max)");
            builder.HasData(Seeder.UserSeed());
        }
    }
}
