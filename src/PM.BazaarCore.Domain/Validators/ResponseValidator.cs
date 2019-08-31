using PM.BazaarCore.Domain.Core.Validators;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Validations.Response;

namespace PM.BazaarCore.Domain.Validators
{
    public sealed class ResponseValidator : Validator<Response>
    {
        public ResponseValidator()
        {
            AddValidation(new LengthResponseValidation());
        }
    }
}
