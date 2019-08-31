using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common
{
    public abstract class PasswordValidatorBase : IPasswordValidator<Account>
    {
        public IdentityErrorDescriber ErrorDescriber { get; private set; }

        public PasswordValidatorBase(IdentityErrorDescriber describer)
        {
            ErrorDescriber = describer;
        }

        public abstract Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user, string password);
    }
}
