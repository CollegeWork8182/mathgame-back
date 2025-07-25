using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Password)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasOne(x => x.Profile)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Rooms)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Participant)
            .WithOne(x => x.User)
            .HasForeignKey<ParticipantEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}