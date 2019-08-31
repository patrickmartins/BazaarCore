using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Values;
using System.Linq;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions
{
    public static class OperationResultExtensions
    {
        public static IdentityResult ToIdentityResult(this OperationResult result)
        {
            var errors = result.Errors.Select(c => new IdentityError() { Code = c.Source, Description = c.Description }).ToList();
                        
            return IdentityResult.Failed(errors.ToArray());
        }

        public static OperationResult ToOperationResult(this IdentityResult result)
        {
            var errors = result.Errors.Select(c => new Error(c.Description, c.Code)).ToList();

            return new OperationResult(errors);
        }
    }
}
