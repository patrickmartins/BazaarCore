using Microsoft.AspNetCore.Authentication;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces
{
    public interface IJwtAuthService
    {
        Task<OperationResult<JwtToken>> SignInAsync(string email, string password);
        Task SignOutAsync();
    }
}
