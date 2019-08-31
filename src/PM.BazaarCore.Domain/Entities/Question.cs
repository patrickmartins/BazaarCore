using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Validators;
using System;

namespace PM.BazaarCore.Domain.Entities
{
    public class Question : Entity
    {
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public virtual Advertiser User { get; private set; }
        public Guid IdUser { get; private set; }
        public virtual Ad Ad { get; private set; }
        public Guid IdAd { get; private set; }
        public virtual Response Response { get; private set; }

        protected Question() { }

        public Question(Guid id, string description, DateTime date, Guid idAdvertiser, Guid idAd)
        {
            Id = id;
            Description = description;
            Date = date;
            IdUser = idAdvertiser;
            IdAd = idAd;
        }

        public Question(Guid id, string description, DateTime date, Advertiser advertiser, Ad ad) : this(id, description, date, advertiser.Id, ad.Id)
        {
            User = advertiser;
            Ad = ad;
        }

        public OperationResult Answer(Response response)
        {
            var result = response.IsValid();

            if (result.Sucess)
                Response = response;

            return new OperationResult(result.Errors.ToArray());
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

        public override ValidationResult IsValid()
        {
            var validator = new QuestionValidator();

            return validator.Validate(this);
        }
    }
}
