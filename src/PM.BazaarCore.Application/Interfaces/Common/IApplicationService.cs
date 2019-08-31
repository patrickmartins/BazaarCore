using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.Interfaces.Common
{
    public interface IApplicationService
    {
        void BeginTransaction();
        void Commit();
        Task CommitAsync();
    }
}
