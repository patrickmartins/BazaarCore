using Microsoft.EntityFrameworkCore.Metadata;

namespace PM.BazaarCore.Infrastructure.Data.Interfaces
{
    public interface IModelConvention
    {
        void Apply(IMutableEntityType entity);
    }
}
