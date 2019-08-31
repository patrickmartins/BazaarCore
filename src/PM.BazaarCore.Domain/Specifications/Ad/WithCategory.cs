using PM.BazaarCore.Domain.Core.Specification;
using System;
using System.Linq;

namespace PM.BazaarCore.Domain.Specifications.Ad
{
    public class WithCategory : SpecificationQuery<Entities.Ad>
    {
        public WithCategory(Guid[] idCategories)
        {
            Expression = c => idCategories.Contains(c.IdCategory);
        }
    }
}
