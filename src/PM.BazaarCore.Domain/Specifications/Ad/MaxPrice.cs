using PM.BazaarCore.Domain.Core.Specification;

namespace PM.BazaarCore.Domain.Specifications.Ad
{
    public class MaxPrice : SpecificationQuery<Entities.Ad>
    {
        public MaxPrice(double price)
        {
            Expression = c => c.Price <= price;
        }
    }
}
