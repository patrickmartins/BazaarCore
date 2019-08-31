using PM.BazaarCore.Domain.Core.Validators;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Validations.Ad;

namespace PM.BazaarCore.Domain.Validators
{
    public sealed class AdValidator : Validator<Ad>
    {
        public AdValidator()
        {
            AddValidation(new MinPriceValidation());
            AddValidation(new LengthDescriptionValidation());
            AddValidation(new LengthTitleValidation());
            AddValidation(new CountPicturesValidation());
        }
    }
}
