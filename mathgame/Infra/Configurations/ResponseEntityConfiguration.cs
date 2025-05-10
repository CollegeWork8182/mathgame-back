using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations
{
    public class ResponseEntityConfiguration : IEntityTypeConfiguration<ResponseEntity>
    {
        public void Configure(EntityTypeBuilder<ResponseEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Correct)
                .IsRequired();

            builder.Property(x => x.Incorrect)
                .IsRequired();

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Responses)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Participant)
                .WithMany(x => x.Responses)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
