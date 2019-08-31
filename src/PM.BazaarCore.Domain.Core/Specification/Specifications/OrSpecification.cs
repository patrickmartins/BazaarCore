using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Interfaces;

namespace PM.BazaarCore.Domain.Core.Specification.Specifications
{
    public class OrSpecification<TEntity> : SpecificationQuery<TEntity> where TEntity : Entity
    {
        public OrSpecification(ISpecificationQuery<TEntity> left, ISpecificationQuery<TEntity> right)
        {
            Expression = MergeExpression(left.GetExpression(), right.GetExpression(), System.Linq.Expressions.Expression.Or);
        }
    }
}
