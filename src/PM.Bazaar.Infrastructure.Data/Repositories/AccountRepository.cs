using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces;
using PM.BazaarCore.Infrastructure.Data.Contexts;
using PM.BazaarCore.Infrastructure.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Infrastructure.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public IQueryable<Account> Users { get; }

        public AccountRepository(BazaarCoreContext context) : base(context)
        {
            Users = context.Set<Account>();
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));
            
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEmailAsync(user, cancellationToken);
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateEmail(userName);

            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetNormalizedEmailAsync(user, cancellationToken);
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            return SetNormalizedEmailAsync(user, normalizedName, cancellationToken);
        }

        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            Context.Add(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            Context.Attach(user);
            Context.Update(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            Context.Remove(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var id = new Guid(userId);

            return FirstOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);
        }

        public Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FindByEmailAsync(normalizedUserName, cancellationToken);
        }

        public Task SetEmailAsync(Account user, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SetUserNameAsync(user, email, cancellationToken);
        }

        public Task<string> GetEmailAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetNormalizedEmailAsync(user, cancellationToken);
        }

        public Task<bool> GetEmailConfirmedAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.ConfirmEmail(confirmed);

            return Task.CompletedTask;
        }

        public Task<Account> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FirstOrDefaultAsync(c => c.NormalizedEmail.Equals(normalizedEmail), cancellationToken);
        }

        public Task<string> GetNormalizedEmailAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.NormalizedEmail);
        }

        public Task SetNormalizedEmailAsync(Account user, string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateNormalizedEmail(normalizedEmail);

            return Task.CompletedTask;
        }

        public async Task<IList<Claim>> GetClaimsAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await Task.FromResult(user.Claims.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList());
        }

        public Task AddClaimsAsync(Account user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            claims.ToList().ForEach(c =>
                user.Claims.Add(new AccountClaim() { Id = Guid.NewGuid(), ClaimType = c.Type, ClaimValue = c.Value }));

            return Task.CompletedTask;
        }

        public async Task ReplaceClaimAsync(Account user, Claim claim, Claim newClaim, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }
            if (newClaim == null)
            {
                throw new ArgumentNullException(nameof(newClaim));
            }

            var matchedClaims = await Context.Set<AccountClaim>().Where(uc => uc.AccountId.Equals(user.Id) && uc.ClaimValue == claim.Value && uc.ClaimType == claim.Type).ToListAsync(cancellationToken);

            foreach (var matchedClaim in matchedClaims)
            {
                matchedClaim.ClaimValue = newClaim.Value;
                matchedClaim.ClaimType = newClaim.Type;
            }
        }

        public async Task RemoveClaimsAsync(Account user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (claims == null)
            {
                throw new ArgumentNullException(nameof(claims));
            }
            foreach (var claim in claims)
            {
                var matchedClaims = await Context.Set<AccountClaim>().Where(uc => uc.AccountId.Equals(user.Id) && uc.ClaimValue == claim.Value && uc.ClaimType == claim.Type).ToListAsync(cancellationToken);
                foreach (var c in matchedClaims)
                {
                    Context.Remove(c);
                }
            }
        }

        public async Task<IList<Account>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            return await Users.Where(c => c.Claims.Any(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value)).ToListAsync(cancellationToken);
        }

        public async Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var roleEntity = await Context.Set<Role>().SingleOrDefaultAsync(r => r.Name == roleName, cancellationToken);

            if (roleEntity == null)
                throw new InvalidOperationException($"A role '{roleName}' não foi encontrada");

            Context.Set<AccountRole>().Add(new AccountRole(){ Account = user, Role = roleEntity });
        }

        public async Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var roleEntity = await Context.Set<Role>().SingleOrDefaultAsync(r => r.Name == roleName, cancellationToken);

            if (roleEntity != null)
            {
                var userRole = await Context.Set<AccountRole>().FirstOrDefaultAsync(c => c.AccountId == user.Id && c.RoleId == roleEntity.Id, cancellationToken);

                if (userRole != null)
                    Context.Set<AccountRole>().Remove(userRole);
            }
        }

        public async Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await Context.Set<AccountRole>().Where(c => c.AccountId == user.Id).Select(c => c.Role.Name).ToListAsync(cancellationToken);
        }

        public async Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var roleEntity = await Context.Set<Role>().SingleOrDefaultAsync(r => r.Name == roleName, cancellationToken);

            if (roleEntity != null)
            {
                var userRole = await Context.Set<AccountRole>().FirstOrDefaultAsync(c => c.AccountId == user.Id && c.RoleId == roleEntity.Id, cancellationToken);

                return userRole != null;
            }

            return false;
        }

        public async Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var roleEntity = await Context.Set<Role>().SingleOrDefaultAsync(r => r.Name == roleName, cancellationToken);

            if (roleEntity != null)
                return await  Context.Set<AccountRole>().Where(c => c.RoleId == roleEntity.Id).Select(c => c.Account).ToListAsync(cancellationToken);

            return new List<Account>();
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.ChangePassword(passwordHash);

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(string.IsNullOrEmpty(user.Password));
        }

        public Task SetSecurityStampAsync(Account user, string stamp, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateSecurityStamp(stamp);

            return Task.CompletedTask;
        }

        public Task<string> GetSecurityStampAsync(Account user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.SecurityStamp);
        }        
    }
}
