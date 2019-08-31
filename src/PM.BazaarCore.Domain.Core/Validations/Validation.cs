using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Core.Validations
{
    public abstract class Validation<TEntity> where TEntity : Entity
    {
        public string Target { get; protected set; }
        public string Error { get; protected set; }
        public abstract ValidationResult IsValid(TEntity entity);
    }
}
