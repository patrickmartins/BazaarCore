using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Ad
{
    public class LengthDescriptionValidation : Validation<Entities.Ad>
    {
        private readonly int _minCharacters = int.Parse(Configs.MinCharactersDescriptionAd);
        private readonly int _maxCharacters = int.Parse(Configs.MaxCharactersDescriptionAd);

        public LengthDescriptionValidation()
        {
            Target = "Description";
            Error = $"A descrição deve conter no mínimo {_minCharacters} e no máximo {_maxCharacters} caracteres";
        }

        public override ValidationResult IsValid(Entities.Ad entity)
        {
            var result = new ValidationResult();

            if (entity.Description.Length < _minCharacters || entity.Description.Length > _maxCharacters)
                result.AddError(Target, Error);

            return result;
        }
    }
}
