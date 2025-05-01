using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations;

public class AccessCodeEntityConfiguration : IEntityTypeConfiguration<AccessCodeEntity>
{
    public void Configure(EntityTypeBuilder<AccessCodeEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Code)
            .IsRequired()  
            .HasMaxLength(50);

        builder.Property(a => a.IsActive)
            .IsRequired(); 

        builder.Property(a => a.IsUserUpdatePassword)
            .IsRequired();

        builder.Property(a => a.ExperationDate)
            .IsRequired();

        builder.HasOne(a => a.User)
            .WithOne(u => u.AccessCode)
            .HasForeignKey<AccessCodeEntity>(a => a.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

    }
}