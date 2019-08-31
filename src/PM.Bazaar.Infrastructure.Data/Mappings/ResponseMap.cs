using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Domain.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class ResponseMap : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description).IsRequired().HasMaxLength(2000);
            builder.Property(c => c.Date).IsRequired();

            builder.HasOne(c => c.Question)
                .WithOne(c => c.Response)
                .HasPrincipalKey<Question>(c => c.Id);

            builder.HasOne(c => c.Advertiser)
                .WithMany(c => c.Responses)
                .HasForeignKey(c => c.IdAdvertiser)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
