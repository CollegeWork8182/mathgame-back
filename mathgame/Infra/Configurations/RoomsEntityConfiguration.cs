using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations
{
    public class RoomsEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(x => x.Participants)
                .WithMany(x => x.Rooms)
                .UsingEntity(x => x.ToTable("Room_Participants"));
                
        }
    }
}
