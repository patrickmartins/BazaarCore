using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Interfaces.Services
{
    public interface IAdvertisingService : IService<Ad>
    {
        OperationResult PublishAd(Ad ad);
        Task<OperationResult> PublishAdAsync(Ad ad, CancellationToken cancellationToken = default(CancellationToken));
        OperationResult RemoveAd(Ad ad);
        OperationResult UpdateAd(Ad ad);
        OperationResult Ask(Ad ad, Question question);
        OperationResult Answer(Ad ad, Response response);
    }
}
