using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;

namespace PM.BazaarCore.Domain.Validations.Picture
{
    public class PictureEmptyValidation : Validation<Entities.Image>
    {
        public PictureEmptyValidation()
        {
            Target = "Bytes";
            Error = "A imagem não deve ser vazia";
        }

        public override ValidationResult IsValid(Entities.Image entity)
        {
            var result = new ValidationResult();

            if (entity.Bytes.Length <= 0)
                result.AddError(Target, Error);

            return result;
        }
    }
}
