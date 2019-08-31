using System;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Core.Interfaces
{
    public interface IUoW : IDisposable
    {
        void BeginTransaction();
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
