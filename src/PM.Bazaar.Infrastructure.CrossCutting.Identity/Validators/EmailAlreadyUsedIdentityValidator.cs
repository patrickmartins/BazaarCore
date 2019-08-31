using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators
{
    public class EmailAlreadyUsedIdentityValidator : UserValidatorBase
    {
        public EmailAlreadyUsedIdentityValidator(IdentityErrorDescriber describer) : base(describer) { }

        public override Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user)
        {
            var result = new ValidationResult();
            var account = manager.FindByEmailAsync(user.Email).Result;

            if (account != null && account.Id != user.Id)
                return Task.FromResult(IdentityResult.Failed(ErrorDescriber.DuplicateEmail(user.Email)));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
