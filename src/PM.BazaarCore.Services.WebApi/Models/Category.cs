using System;

namespace PM.BazaarCore.Services.WebApi.Models
{
    /// <summary>
    /// Dados de uma categoria
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// Identificador da categoria
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Name { get; set; }
    }
}
