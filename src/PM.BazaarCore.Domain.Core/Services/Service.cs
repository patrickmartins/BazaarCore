using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Core.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        protected IRepository<TEntity> Repository { get; private set; }

        private bool _disposed;        

        public Service(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public IQueryable<TEntity> Search(ISpecificationQuery<TEntity> specification)
        {
            Thread.Sleep(15000);
            return Repository.Set().Where(specification.GetExpression());
        }

        public IQueryable<TEntity> Set()
        {
            return Repository.Set();
        }

        public OperationResult<TEntity> GetById(Guid id)
        {
            var result = new OperationResult<TEntity>();
            var entitie = Repository.GetById(id);

            if (entitie != null)
                result.SetValue(entitie);
            else
                result.AddError(new Error("O item informado não foi encontrado", "Id"));

            return result;
        }

        public async Task<OperationResult<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = new OperationResult<TEntity>();
            var entitie = await Repository.GetByIdAsync(id, cancellationToken);

            if (entitie != null)
                result.SetValue(entitie);
            else
                result.AddError(new Error("O item informado não foi encontrado", "Id"));
            
            return result;
        }

        protected OperationResult Insert(TEntity item)
        {
            var result = item.IsValid();

            if (result.Sucess)
                Repository.Insert(item);

            return new OperationResult(result.Errors.ToArray());
        }

        protected async Task<OperationResult> InsertAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            var result = item.IsValid();

            if (result.Sucess)
                await Repository.InsertAsync(item, cancellationToken);

            return new OperationResult(result.Errors.ToArray());
        }

        protected OperationResult Remove(TEntity item)
        {
            var result = GetById(item.Id);

            if (result.Sucess)
                Repository.Remove(result.Value);

            return new OperationResult(result.Errors.ToArray()); 
        }

        protected OperationResult Update(TEntity item)
        {
            var result = GetById(item.Id);

            if (result.Sucess)
            {
                var resultValidate = item.IsValid();

                if (!resultValidate.Sucess)
                    return new OperationResult(resultValidate.Errors.ToArray()); 

                Repository.Update(item);
            }

            return new OperationResult(result.Errors.ToArray());
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
                    Repository.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
