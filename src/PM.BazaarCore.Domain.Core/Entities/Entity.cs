using System;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public abstract ValidationResult IsValid();
    }
}
