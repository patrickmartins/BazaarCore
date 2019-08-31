using PM.BazaarCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.Interfaces
{
    public interface ICategoryApplicationService 
    {
        IEnumerable<Category> AllCategories();
        Task<IEnumerable<Category>> AllCategoriesAsync();
    }
}
