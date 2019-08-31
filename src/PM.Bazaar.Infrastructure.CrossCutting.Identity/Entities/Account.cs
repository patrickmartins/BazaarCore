using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using System.Collections.Generic;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities
{
    public class Account : Entity
    {
        protected Account() { }
        public Account(string email, string password, Advertiser advertiser)
        {
            Email = email;
            NormalizedEmail = email;
            Advertiser = advertiser;
            Password = password;

            Id = advertiser.Id;

            _claims = new HashSet<AccountClaim>();
            _logins = new HashSet<AccountLogin>();
            _roles = new HashSet<AccountRole>();
        }
                
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }
        public string Password { get; private set; }
        public string SecurityStamp { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public virtual Advertiser Advertiser { get; private set; }

        private HashSet<AccountClaim> _claims;
        public virtual ICollection<AccountClaim> Claims => _claims;

        private HashSet<AccountLogin> _logins;
        public virtual ICollection<AccountLogin> Logins => _logins;

        private HashSet<AccountRole> _roles;
        public virtual ICollection<AccountRole> Roles => _roles;

        public void UpdateSecurityStamp(string stamp)
        {
            SecurityStamp = stamp;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateNormalizedEmail(string normalizedEmail)
        {
            NormalizedEmail = normalizedEmail;
        }

        public void ConfirmEmail(bool confirmed)
        {
            EmailConfirmed = confirmed;
        }
        
        public override ValidationResult IsValid()
        {
            return new ValidationResult();
        }
    }
}
