using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using System.Collections.Generic;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities
{
    public class Role : Entity
    {
        public Role()
        {
            AccountRoles = new List<AccountRole>();
        }

        public virtual ICollection<AccountRole> AccountRoles { get; private set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public override ValidationResult IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
