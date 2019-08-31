using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Specification;

namespace PM.BazaarCore.Domain.Specification.Specifications.Common
{
    public class AndSpecification<TEntity> : SpecificationQuery<TEntity> where TEntity : Entity
    {
        public AndSpecification(ISpecificationQuery<TEntity> left, ISpecificationQuery<TEntity> right)
        {
            Expression = MergeExpression(left.GetExpression(), right.GetExpression(), System.Linq.Expressions.Expression.And);
        }
    }
}
