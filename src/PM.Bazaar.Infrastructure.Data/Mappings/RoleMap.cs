using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Name).IsRequired();

            builder.HasMany(u => u.AccountRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(c => c.RoleId);
        }
    }
}
