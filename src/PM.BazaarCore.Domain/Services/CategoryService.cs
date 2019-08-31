using PM.BazaarCore.Domain.Core.Services;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Repositories;
using PM.BazaarCore.Domain.Interfaces.Services;

namespace PM.BazaarCore.Domain.Services
{
    public class CategoryService: Service<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        { }
    }
}
