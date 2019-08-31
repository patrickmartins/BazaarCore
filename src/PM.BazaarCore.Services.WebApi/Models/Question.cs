using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PM.BazaarCore.Services.WebApi.Models
{
    /// <summary>
    /// Dados de uma pergunta
    /// </summary>
    public class QuestionModel
    {
        /// <summary>
        /// Identificador da pergunta
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Descrição da pergunta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data de publicação da pergunta
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Dados do usuário que perguntou
        /// </summary>
        public AdvertiserBasicModel User { get; set; }

        /// <summary>
        /// Dados da resposta do anunciante
        /// </summary>
        public ResponseModel Response { get; set; }
    }

    /// <summary>
    /// Dados para publicação de uma nova pegunta
    /// </summary>
    public class RegisterQuestionModel
    {
        public RegisterQuestionModel()
        {
            Id = Guid.NewGuid();
        }

        [SwaggerIgnore]
        public Guid Id { get; set; }

        [UserId]
        [SwaggerIgnore]
        public Guid IdAdvertiser { get; set; }

        [SwaggerIgnore]
        public Guid IdAd { get; set; }

        /// <summary>
        /// Descrição da pergunta
        /// </summary>
        [Required(ErrorMessage = "A pergunta não pode ser vazia")]
        [StringLength(2000, ErrorMessage = "A pergunta deve conter no minímo 5 e no máximo 2000 caracteres", MinimumLength = 5)]
        public string Description { get; set; }
    }
}