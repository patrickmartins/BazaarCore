using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;
using System.Text.RegularExpressions;

namespace PM.BazaarCore.Domain.Validations.Advertiser
{
    public class FormatLastNameValidation : Validation<Domain.Entities.Advertiser>
    {
        public FormatLastNameValidation()
        {
            Target = "LastName";
            Error = "O sobrenome deve conter somente letras";
        }

        public override ValidationResult IsValid(Entities.Advertiser entity)
        {
            var result = new ValidationResult();

            if (!Regex.Match(entity.LastName ?? string.Empty, @"^[A-Za-zÀ-ú\s]*$").Success)
                result.AddError(Target, Error);

            return result;
        }
    }
}
