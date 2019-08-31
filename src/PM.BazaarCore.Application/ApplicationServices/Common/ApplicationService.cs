using PM.BazaarCore.Application.Interfaces.Common;
using PM.BazaarCore.Domain.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.ApplicationServices.Common
{
    public abstract class ApplicationService : IApplicationService, IDisposable
    {
        protected CancellationToken CancellationToken { get; private set; }

        private readonly IUoW _uow;
        private bool _disposed;

        public ApplicationService(IUoW uow, CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
            _uow = uow;            
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public Task CommitAsync()
        {
            return _uow.CommitAsync(CancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)            
                _uow.Dispose();            

            _disposed = true;
        }
    }
}
