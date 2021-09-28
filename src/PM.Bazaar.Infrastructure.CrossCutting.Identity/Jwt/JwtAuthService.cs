using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Managers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly SignInManager<Account> _signInManager;
        private readonly AccountManager _accountManager;
        private readonly JwtConfiguration _configuration;

        public JwtAuthService(SignInManager<Account> signInManager, AccountManager accountManager, JwtConfiguration configuration)
        {
            _signInManager = signInManager;
            _accountManager = accountManager;
            _configuration = configuration;
        }

        public async Task<OperationResult<JwtToken>> SignInAsync(string email, string password)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!signInResult.Succeeded)
                return new OperationResult<JwtToken>(new Error("Usuário ou senha incorretos", "Login"));

            var accountResult = await _accountManager.GetByEmailAsync(email);            

            return new OperationResult<JwtToken>(await GenerateJwtTokenAsync(accountResult.Value));
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        private async Task<JwtToken> GenerateJwtTokenAsync(Account account)
        {
            var handler = new JwtSecurityTokenHandler();
            var clains = await _accountManager.GetClaimsAsync(account);

            clains.Add(new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()));
            clains.Add(new Claim(JwtRegisteredClaimNames.UniqueName, account.Email));
            clains.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _configuration.Issuer,
                Audience = _configuration.Audience,
                Subject = new ClaimsIdentity(clains),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.Key)), SecurityAlgorithms.HmacSha256)
            });

            var token = handler.WriteToken(securityToken);
            
            return new JwtToken() { AccessToken = token, ExpireIn = DateTime.Now.AddMinutes(_configuration.TokenLifeTime) };
        }
    }
}
