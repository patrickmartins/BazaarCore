using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class AccountRoleMap : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasKey(u => new { u.RoleId, u.AccountId });
        }
    }
}
