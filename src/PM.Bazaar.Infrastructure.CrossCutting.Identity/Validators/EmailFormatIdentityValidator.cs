using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Globalization;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators
{
    public class EmailFormatIdentityValidator : UserValidatorBase
    {
        public EmailFormatIdentityValidator(IdentityErrorDescriber describer) : base(describer) { }

        public override Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user)
        {            
            var result = new ValidationResult();

            if (!Regex.Match(user.Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").Success)
                return Task.FromResult(IdentityResult.Failed(ErrorDescriber.InvalidEmailFormat()));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
