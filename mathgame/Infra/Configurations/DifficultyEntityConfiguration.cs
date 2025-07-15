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
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
