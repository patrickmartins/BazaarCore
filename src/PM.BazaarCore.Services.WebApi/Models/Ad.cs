using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PM.BazaarCore.Services.WebApi.Models
{
    /// <summary>
    /// Dados básicos de um anúncio
    /// </summary>
    public class AdBasicModel
    {
        /// <summary>
        /// Identificador do anúncio
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Título do anúncio
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Identificador da categoria do anúncio
        /// </summary>
        public Guid IdCategory { get; set; }

        /// <summary>
        /// Preço do produto anunciado
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Identificador da imagem do produto anunciado
        /// </summary>
        public Guid Picture { get; set; }
    }

    /// <summary>
    /// Dados com filtros de pesquisa de anúncios
    /// </summary>
    public class SearchAdModel
    {
        /// <summary>
        /// Categorias das publicações
        /// </summary>
        public Guid[] Categories { get; set; }

        /// <summary>
        /// Preço máximo dos produtos anunciados
        /// </summary>
        public double MaxPrice { get; set; }

        /// <summary>
        /// Preço minimo dos produtos anunciados
        /// </summary>
        public double MinPrice { get; set; }

        /// <summary>
        /// Tipo de ordenação dos anúncios
        /// </summary>
        [Range(0, 2, ErrorMessage = "Categoria inválida")]
        public int Order { get; set; }

        /// <summary>
        /// Página da busca
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Palavra chave de busca
        /// </summary>
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A chave de busca deve conter no mínimo 3 e no máximo 20 caracteres")]
        public string KeywordSearch { get; set; }

        /// <summary>
        /// Número de anúncios por página
        /// </summary>
        [Range(5, 50, ErrorMessage = "O tamnho da página deve ser no mínimo 5 e no máximo 50")]
        public int PageSize { get; set; }

        public SearchAdModel()
        {
            KeywordSearch = string.Empty;
            Categories = new Guid[0];
        }
    }

    /// <summary>
    /// Dados detalhados de um anúncio
    /// </summary>
    public class AdDetailedModel
    {
        /// <summary>
        /// Data de publicação do anúncio
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Título do anúncio
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição do produto anunciado
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identificador da categoria do anúncio
        /// </summary>
        public Guid IdCategory { get; set; }

        /// <summary>
        /// Preço do produto anunciado
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Dados do anunciante
        /// </summary>
        public AdvertiserBasicModel Advertiser { get; set; }

        /// <summary>
        /// Array com os identificadores das imagens do produto
        /// </summary>
        public Guid[] Pictures { get; set; }

        /// <summary>
        /// Dados das perguntas publicadas
        /// </summary>
        public ICollection<QuestionModel> Questions { get; set; }
    }

    /// <summary>
    /// Dados para publicação de um novo anúncio
    /// </summary>
    public class RegisterAdModel
    {
        public RegisterAdModel()
        {
            Id = Guid.NewGuid();
        }

        [SwaggerIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Título do anúncio
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "O título deve conter no mínimo 5 e no máximo 60 caracteres")]
        public string Title { get; set; }

        /// <summary>
        /// Descrição do produto a ser anunciado
        /// </summary>
        [Required]
        [StringLength(5000, MinimumLength = 100, ErrorMessage = "A descrição deve conter no mínimo 100 e no máximo 5000 caracteres")]
        public string Description { get; set; }

        /// <summary>
        /// Identificador da categoria do anúncio
        /// </summary>
        [Required]
        public Guid IdCategory { get; set; }

        [UserId]
        [SwaggerIgnore]
        public Guid IdAdvertiser { get; set; }

        /// <summary>
        /// Preço do produto a ser anunciado
        /// </summary>
        [Required]
        [Range(5, 1000, ErrorMessage = "O preço do item deve ser no mínimo R$5 e no máximo R$1000")]
        public double Price { get; set; }

        /// <summary>
        /// Array com os identificadore das imagens do produto
        /// </summary>
        public Guid[] Pictures { get; set; }
    }
}
