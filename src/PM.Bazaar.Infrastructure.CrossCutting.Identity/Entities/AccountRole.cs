using System;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities
{
    public class AccountRole
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
