using PM.BazaarCore.Application.ApplicationServices.Common;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Interfaces.Services;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Managers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.ApplicationServices
{
    public class AccountApplicationService : ApplicationService, IAccountApplicationService
    {
        private readonly AccountManager _userManager;
        private readonly IImageService _imageService;

        private bool _disposed;

        public AccountApplicationService(AccountManager userManager, IImageService imageService, IUoW uow, CancellationToken cancellationToken) : base(uow, cancellationToken)
        {
            _userManager = userManager;
            _imageService = imageService;
        }

        public async Task<OperationResult> ChangePasswordAsync(Guid accountId, string currentPassword, string newPassword)
        {
            BeginTransaction();

            var account = await _userManager.GetByIdAsync(accountId);

            if (!account.Sucess)
                return account;

            var result = (await _userManager.ChangePasswordAsync(account.Value, currentPassword, newPassword)).ToOperationResult();

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public async Task<OperationResult> ChangeAvatarAsync(Guid accountId, Guid imageHash)
        {
            BeginTransaction();

            var resultImage = _imageService.GetById(imageHash);

            if (!resultImage.Sucess)
                return resultImage;

            var resultAccount = await _userManager.GetByIdAsync(accountId);

            if (!resultAccount.Sucess)
                return resultAccount;

            resultAccount.Value.Advertiser.ChangeAvatar(resultImage.Value);

            var result = (await _userManager.UpdateAsync(resultAccount.Value)).ToOperationResult();

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public async Task<OperationResult<Account>> GetByEmailAsync(string email)
        {
            var result = new OperationResult<Account>();

            var account = await _userManager.GetByEmailAsync(email);

            if (account.Sucess)
                result.SetValue(account.Value);
            else
                result.AddErrors(account.Errors);

            return result;
        }

        public async Task<OperationResult<Account>> GetByIdAsync(Guid accountId)
        {
            var result = new OperationResult<Account>();

            var account = await _userManager.GetByIdAsync(accountId);

            if (account.Sucess)
                result.SetValue(account.Value);
            else
                result.AddErrors(account.Errors);

            return result;
        }

        public async Task<OperationResult> CreateAccountAsync(Account account)
        {
            BeginTransaction();

            var result = (await _userManager.CreateAsync(account, account.Password)).ToOperationResult();

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public async Task<OperationResult> RemoveAccountAsync(Account account)
        {
            BeginTransaction();

            var result = (await _userManager.DeleteAsync(account)).ToOperationResult();

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public async Task<OperationResult> UpdateAccountAsync(Account account)
        {
            BeginTransaction();

            var result = (await _userManager.UpdateAsync(account)).ToOperationResult();

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _imageService.Dispose();
                _userManager.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
