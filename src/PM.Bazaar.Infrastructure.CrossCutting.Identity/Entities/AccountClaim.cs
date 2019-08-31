using System;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities
{
    public class AccountClaim
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
