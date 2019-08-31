using System;
using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Validators;

namespace PM.BazaarCore.Domain.Entities
{
    public class Response : Entity
    {
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public virtual Question Question { get; private set; }
        public virtual Advertiser Advertiser { get; private set; }
        public virtual Guid IdAdvertiser { get; private set; }

        protected Response() { }

        public Response(Guid id, string description, DateTime date, Guid idAdvertiser)
        {
            Id = id;
            IdAdvertiser = idAdvertiser;

            Date = date;
            Description = description;                        
        }

        public Response(Guid id, string description, DateTime date, Advertiser advertiser) : this(id, description, date, advertiser.Id)
        {
            Advertiser = advertiser;
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
            var validator = new ResponseValidator();

            return validator.Validate(this);
        }
    }
}
