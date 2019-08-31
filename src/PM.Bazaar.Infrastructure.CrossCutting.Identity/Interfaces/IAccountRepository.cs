using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces
{
    public interface IAccountRepository : IRepository<Account>,
        IUserEmailStore<Account>,
        IUserClaimStore<Account>,
        IUserRoleStore<Account>,
        IUserPasswordStore<Account>,
        IUserSecurityStampStore<Account>,
        IQueryableUserStore<Account>
    { }
}
