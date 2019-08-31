using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Advertiser
{
    public class LengthNameValidation : Validation<Entities.Advertiser>
    {
        private int _minCharacters = int.Parse(Configs.MinCharactersName);
        private int _maxCharacters = int.Parse(Configs.MaxCharactersName);

        public LengthNameValidation()
        {
            Target = "Name";
            Error = $"O nome deve conter no mínimo {_minCharacters} e no máximo {_maxCharacters} caracteres";
        }

        public override ValidationResult IsValid(Entities.Advertiser entity)
        {
            var result = new ValidationResult();

            if (entity.Name.Length < _minCharacters || entity.Name.Length > _maxCharacters)
                result.AddError(Target, Error);

            return result;
        }
    }
}
