using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Core.Interfaces
{
    public interface IValidator<in TEntity> where TEntity : Entity
    {
        ValidationResult Validate(TEntity entity);
    }
}
