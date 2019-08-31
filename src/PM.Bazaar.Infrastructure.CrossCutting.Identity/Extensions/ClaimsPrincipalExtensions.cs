using System;
using System.Security.Claims;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
