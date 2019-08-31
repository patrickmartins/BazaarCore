using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Ad
{
    public class MinPriceValidation : Validation<Domain.Entities.Ad>
    {
        private double _minPrice = double.Parse(Configs.MinProductPrice);
        private double _maxPrice = double.Parse(Configs.MaxProductPrice);

        public MinPriceValidation()
        {
            Target = "Price";
            Error = $"O preço do item deve ser no mínimo R${_minPrice} e no máximo R${_maxPrice}";
        }

        public override ValidationResult IsValid(Entities.Ad entity)
        {
            var result = new ValidationResult();

            if (entity.Price < _minPrice || entity.Price > _maxPrice)
                result.AddError(Target, Error);

            return result;
        }
    }
}
