using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations;

public class OperationDifficultiesEntityConfiguration : IEntityTypeConfiguration<OperationDifficultiesEntity>
{
    public void Configure(EntityTypeBuilder<OperationDifficultiesEntity> builder)
    {
        builder.ToTable("Operation_Difficulties");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Difficulty)
            .WithMany(x => x.OperationDifficulties)
            .HasForeignKey(x => x.DifficultyId);
        
        builder.HasOne(x => x.Operation)
            .WithMany(x => x.OperationDifficulties)
            .HasForeignKey(x => x.OperationId);

        builder.HasOne(x => x.Room)
            .WithOne(x => x.OperationDifficulties)
            .HasForeignKey<RoomEntity>(x => x.OperationDifficultiesId);
    }
}