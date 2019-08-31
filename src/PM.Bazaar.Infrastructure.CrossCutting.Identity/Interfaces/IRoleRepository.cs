using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces
{
    public interface IRoleRepository : IRoleStore<Role>, IRepository<Role>
    { }
}
