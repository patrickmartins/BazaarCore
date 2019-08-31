using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class AccountClaimMap : IEntityTypeConfiguration<AccountClaim>
    {
        public void Configure(EntityTypeBuilder<AccountClaim> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.ClaimType).IsRequired();
            builder.Property(c => c.ClaimValue).IsRequired();
        }
    }
}
