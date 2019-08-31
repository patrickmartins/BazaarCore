using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common
{
    public abstract class UserValidatorBase : IUserValidator<Account>
    {
        public IdentityErrorDescriber ErrorDescriber { get; private set; }

        public UserValidatorBase(IdentityErrorDescriber describer)
        {
            ErrorDescriber = describer;
        }

        public abstract Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user);
    }
}
