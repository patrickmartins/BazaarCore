using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Services.WebApi.Controllers.Common;
using PM.BazaarCore.Services.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Bazaar.Services.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/category")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryApplicationService _service;
        public CategoryController(ICategoryApplicationService service, IMapper mapper, IWebHostEnvironment env) : base(mapper, env)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as categorias cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<CategoryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AllCategories()
        {
            var categories = await _service.AllCategoriesAsync();

            if (!categories.Any())
                return NoContent();

            return Ok(Map<IEnumerable<CategoryModel>>(categories));
        }
    }
}
