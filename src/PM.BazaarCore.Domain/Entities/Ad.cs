using PM.BazaarCore.Domain.Core.Entities;
using PM.BazaarCore.Domain.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using PM.BazaarCore.Domain.Validators;

namespace PM.BazaarCore.Domain.Entities
{
    public class Ad : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public DateTime Date { get; private set; }

        private HashSet<AdImage> _pictures;
        public virtual IReadOnlyCollection<AdImage> Pictures => _pictures;

        private HashSet<Question> _questions;
        public virtual IReadOnlyCollection<Question> Questions => _questions;

        public virtual Category Category { get; private set; }
        public virtual Guid IdCategory { get; private set; }

        public virtual Advertiser Advertiser { get; private set; }
        public virtual Guid IdAdvertiser { get; private set; }

        protected Ad() { }

        public Ad(Guid id, string title, string description, DateTime date, Guid idCategory, double price, Guid idAdvertiser)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Price = price;

            _pictures = new HashSet<AdImage>();
            _questions = new HashSet<Question>();

            IdCategory = idCategory;
            IdAdvertiser = idAdvertiser;
        }

        public Ad(Guid id, string title, string description, DateTime date, Category category, double price, Advertiser advertiser) : this(id, title, description, date, category.Id, price, advertiser.Id)
        {
            Category = category;
            Advertiser = advertiser;
        }

        public override ValidationResult IsValid()
        {
            var validator = new AdValidator();

            return validator.Validate(this);
        }

        public OperationResult AddPicture(AdImage picture)
        {
            var result = picture.IsValid();

            if (result.Sucess)
                _pictures.Add(picture);

            return new OperationResult(result.Errors.ToArray());
        }

        public OperationResult Ask(Question question)
        {
            var result = question.IsValid();

            if (question.IdUser == IdAdvertiser)
                return new OperationResult(new Error("O anunciante não pode fazer uma pergunta em seu próprio anúncio", "IdAdvertiser"));

            if (result.Sucess)
                _questions.Add(question);

            return new OperationResult(result.Errors.ToArray());
        }

        public OperationResult Answer(Response response)
        {
            var question = Questions.FirstOrDefault(c => c.Id == response.Id);

            if (question == null)
                return new OperationResult(new Error("A pergunta para essa resposta não existe", "IdQuestion"));

            if (response.IdAdvertiser != IdAdvertiser)
                return new OperationResult(new Error("Somente o anunciante pode responder uma pergunta", "IdAdvertiser"));

            return question.Answer(response);
        }

        public OperationResult ChangeCategory(Category category)
        {
            var result = category.IsValid();

            if (result.Sucess)
                Category = category;

            return new OperationResult(result.Errors.ToArray());
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

        public void UpdatePrice(double price)
        {
            Price = price;
        }
    }
}
