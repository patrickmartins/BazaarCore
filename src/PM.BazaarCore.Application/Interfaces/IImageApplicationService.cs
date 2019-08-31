using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.Interfaces
{
    public interface IImageApplicationService
    {
        OperationResult SaveImage(Image item);
        Task<OperationResult> SaveImageAsync(Image item);

        OperationResult RemoveImage(Image item);
        Task<OperationResult> RemoveImageAsync(Image item);

        OperationResult<Image> GetById(Guid id);
        Task<OperationResult<Image>> GetByIdAsync(Guid id);
    }
}
