using PM.BazaarCore.Domain.Specification.Specifications.Common;
using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Specification.Util;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PM.BazaarCore.Domain.Core.Specification
{
    public abstract class SpecificationQuery<TEntity> : ISpecificationQuery<TEntity> where TEntity : Entity
    {
        protected Expression<Func<TEntity, bool>> Expression;

        public Expression<Func<TEntity, bool>> GetExpression()
        {
            return Expression;
        }

        public ISpecificationQuery<TEntity> And(ISpecificationQuery<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        public ISpecificationQuery<TEntity> Or(ISpecificationQuery<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        protected Expression<Func<TEntity, bool>> MergeExpression(Expression<Func<TEntity, bool>> first, Expression<Func<TEntity, bool>> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            return System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(merge(first.Body, secondBody), first.Parameters);
        }
    }
}
