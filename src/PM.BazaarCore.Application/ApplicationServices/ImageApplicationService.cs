using PM.BazaarCore.Application.ApplicationServices.Common;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.ApplicationServices
{
    public class ImageApplicationService : ApplicationService, IImageApplicationService
    {
        private readonly IImageService _service;
        private bool _disposed;

        public ImageApplicationService(IImageService service, IUoW uow, CancellationToken cancellationToken) : base(uow, cancellationToken)
        {
            _service = service;
        }

        public ImageApplicationService(IImageService service, IUoW uow) : base(uow, CancellationToken.None) { }

        public OperationResult SaveImage(Image item)
        {
            BeginTransaction();

            var result = _service.SaveImage(item);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> SaveImageAsync(Image item)
        {
            BeginTransaction();

            var result = await _service.SaveImageAsync(item);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public OperationResult RemoveImage(Image item)
        {
            BeginTransaction();

            var result = _service.RemoveImage(item);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> RemoveImageAsync(Image item)
        {
            BeginTransaction();

            var result = _service.RemoveImage(item);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public OperationResult<Image> GetById(Guid id)
        {
            var result = new OperationResult<Image>();

            var ad = _service.GetById(id);

            if (ad.Sucess)
                result.SetValue(ad.Value);
            else
                result.AddErrors(ad.Errors);

            return result;
        }

        public async Task<OperationResult<Image>> GetByIdAsync(Guid id)
        {
            var result = new OperationResult<Image>();

            var ad = await _service.GetByIdAsync(id);

            if (ad.Sucess)
                result.SetValue(ad.Value);
            else
                result.AddErrors(ad.Errors);

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _service.Dispose();

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
