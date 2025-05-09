using mathgame.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mathgame.Infra.Configurations
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Option1)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.Option2)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.Option3)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.CorrectOption)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(x => x.Responses)
                .WithOne(x => x.Question) 
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
