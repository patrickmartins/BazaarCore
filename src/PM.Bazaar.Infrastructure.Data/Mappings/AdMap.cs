using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Domain.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class AdMap : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Description).IsRequired().HasMaxLength(5000);
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Date).IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.IdCategory);

            builder.Metadata.FindNavigation(nameof(Ad.Pictures)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Ad.Questions)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
