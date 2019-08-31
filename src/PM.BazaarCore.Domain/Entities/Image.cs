using System;
using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Validators;

namespace PM.BazaarCore.Domain.Entities
{
    public class Image : Entity
    {
        public byte[] Bytes { get; private set; }

        protected Image() { }

        public Image(Guid id, byte[] bytes)
        {
            Id = id;
            Bytes = bytes;
        }

        public override ValidationResult IsValid()
        {
            var validator = new PictureValidator();

            return validator.Validate(this);
        }
    }

    public class AdImage : Entity
    {
        public Guid IdAd { get; set; }
        public virtual Ad Ad { get; set; }
        public Guid IdImage { get; set; }
        public virtual Image Image { get; set; }

        protected AdImage() { }

        public AdImage(Image image, Ad ad)
        {
            Image = image;
            Ad = ad;

            IdImage = image.Id;
            IdAd = ad.Id;
        }

        public override ValidationResult IsValid()
        {
            var validator = new PictureValidator();

            return validator.Validate(Image);
        }
    }
}
