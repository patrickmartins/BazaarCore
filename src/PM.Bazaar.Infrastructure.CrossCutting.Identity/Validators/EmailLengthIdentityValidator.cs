using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Globalization;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators
{
    public class EmailLengthIdentityValidator : UserValidatorBase
    {
        private readonly int _minCharacters = int.Parse(Configs.MinCharactersEmail);
        private readonly int _maxCharacters = int.Parse(Configs.MaxCharactersEmail);

        public EmailLengthIdentityValidator(IdentityErrorDescriber describer) : base(describer) { }

        public override Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user)
        {
            var result = new ValidationResult();

            if (user.Email.Length < _minCharacters || user.Email.Length > _maxCharacters)
                return Task.FromResult(IdentityResult.Failed(ErrorDescriber.InvalidEmailFormat()));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
