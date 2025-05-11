using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations
{
    public class ParticipantEntityConfiguration : IEntityTypeConfiguration<ParticipantEntity>
    {
        public void Configure(EntityTypeBuilder<ParticipantEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QtdResponses)
                .IsRequired();

            builder.Property(x => x.Score)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(x => x.Participant)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Responses)
                .WithOne(x => x.Participant)
                .HasForeignKey(x => x.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
