using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Advertiser
{
    public class LengthLastNameValidation : Validation<Entities.Advertiser>
    {
        private readonly int _minCharacters = int.Parse(Configs.MinCharactersLastName);
        private readonly int _maxCharacters = int.Parse(Configs.MaxCharactersLastName);

        public LengthLastNameValidation()
        {
            Target = "LastName";
            Error = $"O sobrenome deve conter no mínimo {_minCharacters} e no máximo {_maxCharacters} caracteres";
        }

        public override ValidationResult IsValid(Entities.Advertiser entity)
        {
            var result = new ValidationResult();

            if (entity.LastName.Length < _minCharacters || entity.LastName.Length > _maxCharacters)
                result.AddError(Target, Error);

            return result;
        }
    }
}
