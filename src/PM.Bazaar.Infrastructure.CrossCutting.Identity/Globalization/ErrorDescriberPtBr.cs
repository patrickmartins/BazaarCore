using Microsoft.AspNetCore.Identity;
using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;

namespace PM.BazaarCore.Infrastructure.CrossCutting.Identity.Globalization
{
    public class ErrorDescriberPtBr : IdentityErrorDescriber
    {        
        private readonly int _minPasswordCharacters = int.Parse(Configs.MinCharactersPassword);
        private readonly int _maxPasswordCharacters = int.Parse(Configs.MaxCharactersPassword);

        public override IdentityError DuplicateEmail(string email) => new IdentityError() { Code = "Email", Description = "O e-mail informado já está sendo usado por outra conta" };        
        public override IdentityError DuplicateUserName(string userName) => new IdentityError() { Code = "Email", Description = "O e-mail informado já está sendo usado por outra conta" };
        public override IdentityError InvalidEmail(string email) => new IdentityError() { Code = "Email", Description = "O e-mail informado é inválido" };
        public override IdentityError InvalidUserName(string userName) => new IdentityError() { Code = "Email", Description = "O e-mail informado é inválido" };
        public override IdentityError PasswordTooShort(int length) => new IdentityError() { Code = "Password", Description = $"A senha deve conter no mínimo {_minPasswordCharacters} e no máximo {_maxPasswordCharacters} caracteres" };
        public override IdentityError PasswordMismatch() => new IdentityError() { Code = "CurrentPassword", Description = "A senha informada está incorreta" };
    }

    public static class IdentityErrorDescriberExtensions
    {
        private static readonly int _maxCharactersEmail = int.Parse(Configs.MaxCharactersEmail);

        public static IdentityError InvalidEmailFormat(this IdentityErrorDescriber describer) => new IdentityError() { Code = "Email", Description = "O e-mail está em um formato incorreto" };
        public static IdentityError EmailTooLong(this IdentityErrorDescriber describer) => new IdentityError() { Code = "Email", Description = $"O email deve conter no máximo {_maxCharactersEmail} caracteres" };
        public static IdentityError EmailRequired(this IdentityErrorDescriber describer) => new IdentityError() { Code = "Email", Description = "O e-mail não foi informado" };

    }
}
