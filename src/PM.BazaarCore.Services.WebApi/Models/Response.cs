using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PM.BazaarCore.Services.WebApi.Models
{
    /// <summary>
    /// Dados de uma resposta
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Descrição da resposta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data de publicação da resposta
        /// </summary>
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Dados de publicação de uma nova resposta
    /// </summary>
    public class RegisterResponseModel
    {
        [UserId]
        [SwaggerIgnore]
        public Guid IdAdvertiser { get; set; }

        [SwaggerIgnore]
        public Guid IdAd { get; set; }

        [SwaggerIgnore]
        public Guid IdQuestion { get; set; }

        /// <summary>
        /// Descrição da resposta
        /// </summary>
        [Required(ErrorMessage = "A resposta não pode ser vazia")]
        [StringLength(2000, ErrorMessage = "A resposta deve conter no minímo 5 e no máximo 2000 caracteres", MinimumLength = 5)]
        public string Description { get; set; }
    }
}