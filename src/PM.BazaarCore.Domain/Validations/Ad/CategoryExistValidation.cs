using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Interfaces.Repositories;

namespace PM.BazaarCore.Domain.Validations.Ad
{
    public class CategoryExistValidation : Validation<Entities.Ad>
    {
        private readonly ICategoryRepository _repository;

        public CategoryExistValidation(ICategoryRepository repository)
        {
            Target = "Category";
            Error = "A categoria informada não é válida";

            _repository = repository;
        }

        public override ValidationResult IsValid(Entities.Ad entity)
        {
            var result = new ValidationResult();

            if (_repository.GetById(entity.IdCategory) == null)
                result.AddError(Target, Error);

            return result;
        }
    }
}
