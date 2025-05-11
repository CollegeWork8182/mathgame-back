using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations
{
    public class OperationEntityConfiguration : IEntityTypeConfiguration<OperationEntity>
    {
        public void Configure(EntityTypeBuilder<OperationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
