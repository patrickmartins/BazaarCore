using Microsoft.EntityFrameworkCore;
using PM.BazaarCore.Infrastructure.Data.Contexts.Conventions;
using PM.BazaarCore.Infrastructure.Data.Extensions;
using PM.BazaarCore.Infrastructure.Data.Mappings;

namespace PM.BazaarCore.Infrastructure.Data.Contexts
{
    public class BazaarCoreContext : DbContext
    {
        public BazaarCoreContext() { }
        public BazaarCoreContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdMap());
            modelBuilder.ApplyConfiguration(new AdvertiserMap());
            modelBuilder.ApplyConfiguration(new ImageMap());
            modelBuilder.ApplyConfiguration(new ImageAdMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new ResponseMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());

            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new AccountClaimMap());
            modelBuilder.ApplyConfiguration(new AccountLoginMap());
            modelBuilder.ApplyConfiguration(new AccountRoleMap());
            modelBuilder.ApplyConfiguration(new RoleMap());

            modelBuilder.ApplyConvention(new UnderscoreAndSeparatePropertyNameConvention());
            modelBuilder.ApplyConvention(new UnderscoreAndSeparateTableNameConvention());

            base.OnModelCreating(modelBuilder);
        }
    }
}
