using PM.BazaarCore.Domain.Core.Validators;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Validations.Advertiser;

namespace PM.BazaarCore.Domain.Validators
{
    public sealed class AdvertiserValidator : Validator<Advertiser>
    {
        public AdvertiserValidator()
        {
            AddValidation(new FormatNameValidation());
            AddValidation(new LengthNameValidation());
            AddValidation(new FormatLastNameValidation());
            AddValidation(new LengthLastNameValidation());
            AddValidation(new PictureRequiredValidation());
        }
    }
}
