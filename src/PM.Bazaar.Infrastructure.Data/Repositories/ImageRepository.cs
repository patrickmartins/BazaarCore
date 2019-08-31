using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Repositories;
using PM.BazaarCore.Infrastructure.Data.Contexts;
using PM.BazaarCore.Infrastructure.Data.Repositories.Common;

namespace PM.BazaarCore.Infrastructure.Data.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(BazaarCoreContext context) : base(context)
        { }
    }
}
