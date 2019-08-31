using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Globalization;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators
{
    public class EmailIsRequiredIdentityValidator : UserValidatorBase
    {
        public EmailIsRequiredIdentityValidator(IdentityErrorDescriber describer) : base(describer) { }

        public override Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user)
        {
            var result = new ValidationResult();

            if (string.IsNullOrEmpty(user.Email))
                return Task.FromResult(IdentityResult.Failed(ErrorDescriber.EmailRequired()));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
