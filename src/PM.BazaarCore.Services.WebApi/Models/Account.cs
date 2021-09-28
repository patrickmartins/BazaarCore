using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt;
using System;
using System.ComponentModel.DataAnnotations;

namespace PM.BazaarCore.Services.WebApi.Models
{
    /// <summary>
    /// Dados detalhados de um usuário
    /// </summary>
    public class AccountModel
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome do usuário
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Identificador da imagem de perfil do usuário
        /// </summary>
        public Guid Avatar { get; set; }
    }

    /// <summary>
    /// Dados do usuário logado
    /// </summary>
    public class LoginSucessModel
    {
        /// <summary>
        /// Dados do usuário
        /// </summary>
        public AccountModel User { get; set; }

        /// <summary>
        /// Token de acesso
        /// </summary>
        public JwtToken Token { get; set; }
    }

    /// <summary>
    /// Dados básicos de um usuário
    /// </summary>
    public class AdvertiserBasicModel
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identificador da imagem de perfil do usuário
        /// </summary>
        public Guid Avatar { get; set; }
    }

    /// <summary>
    /// Dados para troca de senha de um usuário
    /// </summary>
    public class ChangePasswordModel
    {
        /// <summary>
        /// Senha atual
        /// </summary>
        [Required(ErrorMessage = "A senha atual é obrigatória")]
        [StringLength(15, ErrorMessage = "A senha antiga deve conter no minímo 6 e no máximo 15 caracteres", MinimumLength = 6)]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Nova senha
        /// </summary>
        [Required(ErrorMessage = "A nova senha é obrigatória")]
        [StringLength(15, ErrorMessage = "A senha deve conter no minímo 6 e no máximo 15 caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        /// <summary>
        /// Confirmação da senha
        /// </summary>
        [Required(ErrorMessage = "A confirmação da senha é obrigatória")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não correspondem")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Dados de login de um usuário
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        [StringLength(100, ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(15, ErrorMessage = "A senha deve conter no minímo 6 e no máximo 15 caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }

    /// <summary>
    /// Dados de registro de um novo usuário
    /// </summary>
    public class RegisterAccountModel
    {
        public RegisterAccountModel()
        {
            Id = Guid.NewGuid();
        }

        [SwaggerIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(15, ErrorMessage = "O nome deve conter no minímo 5 e no máximo 15 caracteres", MinimumLength = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [StringLength(30, ErrorMessage = "O sobrenome deve conter no minímo 5 e no máximo 30 caracteres", MinimumLength = 5)]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        [StringLength(100, ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(15, ErrorMessage = "A senha deve conter no minímo 6 e no máximo 15 caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        /// <summary>
        /// Confirmação da senha
        /// </summary>
        [Required(ErrorMessage = "A confirmação da senha é obrigatória")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação não correspondem")]
        public string ConfirmPassword { get; set; }
    }
}