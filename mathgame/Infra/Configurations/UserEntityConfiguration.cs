using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educationalapp.Infra.Configurations;

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
    }
}