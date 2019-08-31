using PM.BazaarCore.Domain.Core.Specification;

namespace PM.BazaarCore.Domain.Specifications.Ad
{
    public class MinPrice : SpecificationQuery<Entities.Ad>
    {
        public MinPrice(double price)
        {
            Expression = c => c.Price >= price;
        }
    }
}
