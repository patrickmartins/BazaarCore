using System;
using System.Linq.Expressions;
using PM.BazaarCore.Domain.Core.Entities;

namespace PM.BazaarCore.Domain.Core.Interfaces
{
    public interface ISpecificationQuery<TEntity> where TEntity : Entity
    {
        Expression<Func<TEntity, bool>> GetExpression();
        ISpecificationQuery<TEntity> And(ISpecificationQuery<TEntity> specification);
        ISpecificationQuery<TEntity> Or(ISpecificationQuery<TEntity> specification);
    }
}
