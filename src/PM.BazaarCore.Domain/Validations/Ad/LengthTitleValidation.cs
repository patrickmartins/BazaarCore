using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Ad
{
    public class LengthTitleValidation : Validation<Entities.Ad>
    {
        private int _minCharacters = int.Parse(Configs.MinCharactersTitleAd);
        private int _maxCharacters = int.Parse(Configs.MaxCharactersTitleAd);

        public LengthTitleValidation()
        {
            Target = "Title";
            Error = $"O título deve conter no mínimo {_minCharacters} e no máximo {_maxCharacters} caracteres";
        }

        public override ValidationResult IsValid(Entities.Ad entity)
        {
            var result = new ValidationResult();

            if (entity.Title.Length < _minCharacters || entity.Title.Length > _maxCharacters)
                result.AddError(Target, Error);

            return result;
        }
    }
}
