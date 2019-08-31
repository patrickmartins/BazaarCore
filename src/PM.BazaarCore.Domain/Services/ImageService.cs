using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Services;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Repositories;
using PM.BazaarCore.Domain.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Services
{
    public class ImageService : Service<Image>, IImageService
    {
        public ImageService(IImageRepository repository) : base(repository)
        { }

        public OperationResult RemoveImage(Image image)
        {
            return Remove(image);
        }

        public OperationResult SaveImage(Image image)
        {
            return Insert(image);
        }

        public Task<OperationResult> SaveImageAsync(Image image, CancellationToken cancellationToken = default(CancellationToken))
        {            
            return InsertAsync(image, cancellationToken);
        }
    }
}
