using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Advertiser
{
    public class PictureRequiredValidation : Validation<Entities.Advertiser>
    {
        public PictureRequiredValidation()
        {
            Target = "Picture";
            Error = "A foto de perfil deve ser informada";
        }

        public override ValidationResult IsValid(Entities.Advertiser entity)
        {
            var result = new ValidationResult();

            if (entity.Avatar == null)
                result.AddError(Target, Error);

            return result;
        }
    }
}
