using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using System;

namespace PM.BazaarCore.Domain.Entities
{
    public class Category : Entity
    {
        protected Category() { }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public override ValidationResult IsValid()
        {
            return new ValidationResult();
        }
    }
}
