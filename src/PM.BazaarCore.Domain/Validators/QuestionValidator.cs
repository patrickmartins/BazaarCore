using PM.BazaarCore.Domain.Core.Validators;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Validations.Question;

namespace PM.BazaarCore.Domain.Validators
{
    public sealed class QuestionValidator : Validator<Question>
    {
        public QuestionValidator()
        {
            AddValidation(new LengthQuestionValidation());
        }
    }
}
