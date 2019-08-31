using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Domain.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Bytes).IsRequired();
        }
    }

    public class ImageAdMap : IEntityTypeConfiguration<AdImage>
    {
        public void Configure(EntityTypeBuilder<AdImage> builder)
        {
            builder.HasKey(c => new { c.IdImage, c.IdAd });

            builder.Ignore(c => c.Id);

            builder.HasOne(c => c.Ad)
                .WithMany(c => c.Pictures)
                .HasForeignKey(c => c.IdAd);

            builder.HasOne(c => c.Image)
                .WithMany()
                .HasForeignKey(c => c.IdImage);
        }
    }
}
