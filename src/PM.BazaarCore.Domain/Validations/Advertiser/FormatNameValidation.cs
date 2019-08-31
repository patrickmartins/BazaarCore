using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;
using System.Text.RegularExpressions;

namespace PM.BazaarCore.Domain.Validations.Advertiser
{
    public class FormatNameValidation : Validation<Domain.Entities.Advertiser>
    {
        public FormatNameValidation()
        {
            Target = "Name";
            Error = "O nome deve conter somente letras";
        }

        public override ValidationResult IsValid(Entities.Advertiser entity)
        {
            var result = new ValidationResult();

            if (!Regex.Match(entity.Name, @"^[A-Za-zÀ-ú\s]*$").Success)
                result.AddError(Target, Error);

            return result;
        }
    }
}
