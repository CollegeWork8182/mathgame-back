using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations
{
    public class DifficultyEntityConfiguration : IEntityTypeConfiguration<DifficultyEntity>
    {
        public void Configure(EntityTypeBuilder<DifficultyEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.Difficulty)
                .HasForeignKey(x => x.DifficultyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
