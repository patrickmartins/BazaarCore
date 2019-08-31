using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;
using System.Collections.Generic;

namespace PM.BazaarCore.Domain.Core.Validators
{
    public class Validator<TEntity> : IValidator<TEntity> where TEntity : Entity
    {
        private readonly ICollection<Validation<TEntity>> _validations;

        public Validator()
        {
            _validations = new HashSet<Validation<TEntity>>();
        }

        public virtual void AddValidation(Validation<TEntity> validation)
        {
            _validations.Add(validation);
        }

        public virtual void RemoveValidation(Validation<TEntity> validation)
        {
            _validations.Remove(validation);
        }

        public ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();

            foreach (var validation in _validations)
            {
                var res = validation.IsValid(entity);

                if (!res.Sucess)
                    result.AddErrors(res.Errors);
            }

            return result;
        }
    }
}
