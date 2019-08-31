using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Managers
{
    public class AccountManager : UserManager<Account>
    {
        private readonly CancellationToken _cancellationToken;

        public AccountManager(IUserStore<Account> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Account> passwordHasher,
            IEnumerable<IUserValidator<Account>> userValidators,
            IEnumerable<IPasswordValidator<Account>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Account>> logger,
            CancellationToken cancellationToken) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _cancellationToken = cancellationToken;
        }

        protected override CancellationToken CancellationToken => _cancellationToken;

        public async Task<OperationResult<Account>> GetByIdAsync(Guid id)
        {
            var result = new OperationResult<Account>();

            var entitie = await FindByIdAsync(id.ToString());
            
            if (entitie != null)
                result.SetValue(entitie);
            else
                result.AddError(new Error("A conta informada não foi encontrada", "Id"));
            
            return result;
        }

        public async Task<OperationResult<Account>> GetByEmailAsync(string email)
        {
            var result = new OperationResult<Account>();
            var entitie = await FindByEmailAsync(email);

            if (entitie != null)
                result.SetValue(entitie);
            else
                result.AddError(new Error("A conta informada não foi encontrada", "Id"));

            return result;
        }
    }
}
