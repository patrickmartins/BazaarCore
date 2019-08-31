using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class AccountLoginMap : IEntityTypeConfiguration<AccountLogin>
    {
        public void Configure(EntityTypeBuilder<AccountLogin> builder)
        {
            builder.HasKey(u => new { u.AccountId, u.LoginProvider, u.ProviderKey });
        }
    }
}
