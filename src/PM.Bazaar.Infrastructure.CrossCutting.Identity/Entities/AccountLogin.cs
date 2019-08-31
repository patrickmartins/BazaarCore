using System;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities
{
    public class AccountLogin
    {
        public Guid AccountId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
