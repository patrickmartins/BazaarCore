using PM.BazaarCore.Domain.Core.Specification;

namespace PM.BazaarCore.Domain.Specifications.Ad
{
    public class WithKeywordInTitle : SpecificationQuery<Entities.Ad>
    {
        public WithKeywordInTitle(string keyword)
        {
            Expression = c => c.Title.Contains(keyword);
        }
    }
}
