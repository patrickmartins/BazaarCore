using System.Collections.Generic;
using System.Linq;

namespace PM.BazaarCore.Domain.Core.Values.Common
{
    public abstract class Result
    {
        protected Result(params Error[] errors)
        {
            Errors = errors.ToList();
        }

        protected Result(List<Error> errors)
        {
            Errors = errors;
        }

        public Result()
        {
            Errors = new List<Error>();
        }

        public List<Error> Errors { get; private set; }
        public bool Sucess => !Errors.Any();

        public void AddError(string source, string description)
        {
            Errors.Add(new Error(description, source));
        }

        public void AddError(Error error)
        {
            Errors.Add(error);
        }

        public void AddErrors(IList<Error> errors)
        {
            Errors = Errors.Concat(errors).ToList();
        }
    }
}
