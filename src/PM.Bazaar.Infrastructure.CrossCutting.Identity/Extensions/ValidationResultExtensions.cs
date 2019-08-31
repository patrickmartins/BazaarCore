using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using System.Linq;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions
{
    public static class ValidationResultExtensions
    {
        public static IdentityResult ToIdentityResult(this ValidationResult result)
        {
            var errors = result.Errors.Select(c => new IdentityError() { Code = c.Source, Description = c.Description });
                        
            return IdentityResult.Failed(errors.ToArray());
        }
    }
}
