using PM.BazaarCore.Domain.Core.Validators;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Validations.Picture;

namespace PM.BazaarCore.Domain.Validators
{
    public sealed class PictureValidator : Validator<Image>
    {
        public PictureValidator()
        {
            AddValidation(new PictureEmptyValidation());
        }
    }
}
