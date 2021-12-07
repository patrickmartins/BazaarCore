using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Domain.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class AdvertiserMap : IEntityTypeConfiguration<Advertiser>
    {
        public void Configure(EntityTypeBuilder<Advertiser> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(15);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(30);

            builder.Property(c => c.RegistrationDate).IsRequired();

            builder.HasMany(c => c.Ads)
                .WithOne(c => c.Advertiser)
                .HasForeignKey(c => c.IdAdvertiser);

            builder.HasOne(c => c.Avatar)
                .WithMany()
                .HasForeignKey(c => c.IdAvatar)                
                .OnDelete(DeleteBehavior.Restrict);

            builder.Metadata.FindNavigation(nameof(Advertiser.Ads)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Advertiser.Questions)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Advertiser.Responses)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
