using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Domain.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Description).IsRequired().HasMaxLength(2000);
            builder.Property(c => c.Date).IsRequired();

            builder.HasOne(c => c.Ad)
                .WithMany(c => c.Questions)
                .HasForeignKey(c => c.IdAd)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Questions)
                .HasForeignKey(c => c.IdUser);
        }
    }
}
