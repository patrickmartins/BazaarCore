using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Interfaces.Services
{
    public interface IImageService : IService<Image>
    {
        OperationResult SaveImage(Image image);
        Task<OperationResult> SaveImageAsync(Image image, CancellationToken cancellationToken = default(CancellationToken));
        OperationResult RemoveImage(Image image);
    }
}
