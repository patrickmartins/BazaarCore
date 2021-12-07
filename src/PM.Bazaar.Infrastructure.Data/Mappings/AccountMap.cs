using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;

namespace PM.BazaarCore.Infrastructure.Data.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(60);
            builder.Property(c => c.NormalizedEmail).IsRequired().HasMaxLength(60);
            builder.Property(c => c.EmailConfirmed);

            builder.HasMany(u => u.Claims)
                .WithOne()
                .HasForeignKey(u => u.AccountId);

            builder.HasMany(u => u.Logins)
                .WithOne()
                .HasForeignKey(u => u.AccountId);

            builder.HasMany(u => u.Roles)
                .WithOne(u => u.Account)
                .HasForeignKey(u => u.AccountId);

            builder.HasOne(u => u.Advertiser)
                .WithOne()
                .HasForeignKey<Account>(c => c.Id);

            builder.Metadata.FindNavigation(nameof(Account.Claims)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Account.Logins)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Account.Roles)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }    
}
