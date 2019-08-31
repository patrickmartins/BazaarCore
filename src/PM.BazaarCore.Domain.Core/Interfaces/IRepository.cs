using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using PM.BazaarCore.Domain.Core.Entities;

namespace PM.BazaarCore.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IQueryable<TEntity> Set();
        void Insert(TEntity item);
        Task InsertAsync(TEntity item, CancellationToken cancellationToken);
        TEntity Remove(TEntity item);
        void Update(TEntity item);
        bool Contains(TEntity item);
        Task<bool> ContainsAsync(TEntity item, CancellationToken cancellationToken);
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        IQueryable<TEntity> Take(int count);
        IQueryable<TEntity> Skip(int count);
        IQueryable<TEntity> OrderBy<TType>(Expression<Func<TEntity, TType>> predicate);
        IQueryable<TEntity> OrderByDescending<TType>(Expression<Func<TEntity, TType>> predicate);
        int Count();
        Task<int> CountAsync(CancellationToken cancellationToken);
        void ExecuteCommand(string query);
        Task ExecuteCommandAsync(string query, CancellationToken cancellationToken);
        void ExecuteCommand(string query, params object[] parameters);
        Task ExecuteCommandAsync(string query, object[] parameters, CancellationToken cancellationToken);
    }
}
