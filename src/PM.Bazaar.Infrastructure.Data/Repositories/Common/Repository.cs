using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Infrastructure.Data.Contexts;

namespace PM.BazaarCore.Infrastructure.Data.Repositories.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly BazaarCoreContext Context;
        private bool _disposed;

        public Repository(BazaarCoreContext context)
        {
            Context = context;
        }

        public TEntity GetById(Guid id)
        {
            return Context.Set<TEntity>().FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<TEntity> Set()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public bool Contains(TEntity item)
        {
            return Context.Set<TEntity>().Contains(item);
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        public IQueryable<TEntity> OrderBy<TType>(Expression<Func<TEntity, TType>> predicate)
        {
            return Context.Set<TEntity>().OrderBy(predicate);
        }

        public IQueryable<TEntity> OrderByDescending<TType>(Expression<Func<TEntity, TType>> predicate)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public TEntity FirstOrDefault()
        {
            return Context.Set<TEntity>().FirstOrDefault();
        }

        public IQueryable<TEntity> Skip(int count)
        {
            return Context.Set<TEntity>().Skip(count);
        }

        public IQueryable<TEntity> Take(int count)
        {
            return Context.Set<TEntity>().Take(count);
        }

        public void Insert(TEntity item)
        {
            Context.Add(item);
        }

        public TEntity Remove(TEntity item)
        {
            return Context.Remove(item).Entity;
        }

        public void Update(TEntity item)
        {
            Context.Set<TEntity>().Update(item);            
        }

        public Task InsertAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            return Context.AddAsync(item, cancellationToken).AsTask();
        }

        public Task<bool> ContainsAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().ContainsAsync(item, cancellationToken);
        }

        public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().CountAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
