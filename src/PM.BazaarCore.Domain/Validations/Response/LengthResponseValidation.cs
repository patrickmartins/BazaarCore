using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Response
{
    public class LengthResponseValidation : Validation<Entities.Response>
    {
        private int _minCharacters = int.Parse(Configs.MinCharactersQuestion);
        private int _maxCharacters = int.Parse(Configs.MaxCharactersQuestion);

        public LengthResponseValidation()
        {
            Target = "Response";
            Error = $"A resposta deve conter no mínimo {_minCharacters} e no máximo {_maxCharacters} caracteres";
        }

        public override ValidationResult IsValid(Entities.Response entity)
        {
            var result = new ValidationResult();

            if (entity.Description.Length < _minCharacters || entity.Description.Length > _maxCharacters)
                result.AddError(Target, Error);

            return result;
        }
    }
}
