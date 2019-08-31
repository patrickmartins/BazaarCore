using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators
{
    public class PasswordLengthIdentityValidator : PasswordValidatorBase
    {
        private readonly int _minCharacters = int.Parse(Configs.MinCharactersPassword);
        private readonly int _maxCharacters = int.Parse(Configs.MaxCharactersPassword);

        public PasswordLengthIdentityValidator(IdentityErrorDescriber describer) : base(describer) { }

        public override Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user, string password)
        {
            var result = new ValidationResult();

            if (password.Length < _minCharacters || password.Length > _maxCharacters)
                return Task.FromResult(IdentityResult.Failed(ErrorDescriber.PasswordTooShort(0)));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
