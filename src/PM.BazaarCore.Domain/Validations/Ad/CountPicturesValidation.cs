using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Domain.Core.Validations;
using PM.BazaarCore.Domain.Core.Values;
using System.Linq;

namespace PM.BazaarCore.Domain.Validations.Ad
{
    public class CountPicturesValidation : Validation<Entities.Ad>
    {
        private double _minPicture = double.Parse(Configs.MinPicturesAd);
        private double _maxPicture = double.Parse(Configs.MaxPicturesAd);

        public CountPicturesValidation()
        {
            Target = "Pictures";
            Error = $"O anúncio deve conter no mínimo {_minPicture} e no máximo {_maxPicture} fotos do produto";
        }

        public override ValidationResult IsValid(Entities.Ad entity)
        {
            var result = new ValidationResult();

            if (!entity.Pictures.Any())
                result.AddError(Target, Error);

            return result;
        }
    }
}
