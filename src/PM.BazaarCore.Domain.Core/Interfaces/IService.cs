using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Core.Interfaces
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity
    {
        IQueryable<TEntity> Search(ISpecificationQuery<TEntity> specification);
        IQueryable<TEntity> Set();
        OperationResult<TEntity> GetById(Guid id);
        Task<OperationResult<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}