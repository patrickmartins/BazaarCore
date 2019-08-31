using Microsoft.EntityFrameworkCore;
using PM.BazaarCore.Infrastructure.Data.Interfaces;

namespace PM.BazaarCore.Infrastructure.Data.Extensions
{
    public static class ModelBuilderConventionsExtensions
    {
        public static void ApplyConvention(this ModelBuilder modelBuilder, IModelConvention convention)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                convention.Apply(entityType);
        }
    }
}
