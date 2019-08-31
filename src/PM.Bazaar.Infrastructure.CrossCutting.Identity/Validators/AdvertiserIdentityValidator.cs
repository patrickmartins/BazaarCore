using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators.Common;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators
{
    public class AdvertiserIdentityValidator : UserValidatorBase
    {
        public AdvertiserIdentityValidator(IdentityErrorDescriber describer) : base(describer) { }

        public override Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user)
        {            
            return Task.FromResult(user.Advertiser.IsValid().ToIdentityResult());
        }
    }
}
