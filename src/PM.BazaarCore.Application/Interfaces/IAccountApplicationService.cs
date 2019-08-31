using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using System;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.Interfaces
{
    public interface IAccountApplicationService 
    {
        Task<OperationResult> CreateAccountAsync(Account item);
        Task<OperationResult> UpdateAccountAsync(Account item);
        Task<OperationResult<Account>> GetByIdAsync(Guid accountId);
        Task<OperationResult> ChangePasswordAsync(Guid accountId, string currentPassword, string newPassword);
        Task<OperationResult> ChangeAvatarAsync(Guid accountId, Guid imageId);
        Task<OperationResult<Account>> GetByEmailAsync(string email);
    }
}
