using System;
using System.Collections.Generic;
using System.Linq;
using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Validators;

namespace PM.BazaarCore.Domain.Entities
{
    public class Advertiser : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public Guid IdAvatar { get; private set; }
        public virtual Image Avatar { get; private set; }

        private HashSet<Ad> _ads;
        public virtual IReadOnlyCollection<Ad> Ads => _ads;

        private HashSet<Question> _questions;
        public virtual IReadOnlyCollection<Question> Questions => _questions;

        private HashSet<Response> _responses;
        public virtual IReadOnlyCollection<Response> Responses => _responses;

        protected Advertiser() { }

        public Advertiser(Guid id, string name, string lastName, DateTime registrationDate, Image avatar)
        {
            Id = id;
            IdAvatar = avatar.Id;

            Name = name;
            LastName = lastName;
            RegistrationDate = registrationDate;
            Avatar = avatar;

            _ads = new HashSet<Ad>();
            _questions = new HashSet<Question>();
            _responses = new HashSet<Response>();
        }

        public OperationResult ChangeAvatar(Image avatar)
        {
            var result = avatar.IsValid();

            if (result.Sucess)
                Avatar = avatar;

            return new OperationResult(result.Errors.ToArray());
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void ChangeLastName(string newLastName)
        {
            LastName = newLastName;
        }
        
        public override ValidationResult IsValid()
        {
            var validator = new AdvertiserValidator();

            return validator.Validate(this);
        }
    }
}
