using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.BazaarCore.Application.Enuns;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Services.WebApi.Controllers.Common;
using PM.BazaarCore.Services.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Bazaar.Services.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/ad")]
    [ApiController]
    public class AdController : BaseController
    {
        private readonly IAdvertisingApplicationService _service;

        public AdController(IAdvertisingApplicationService service, IMapper mapper, IHostingEnvironment env) : base(mapper, env)
        {
            _service = service;
        }

        /// <summary>
        /// Busca os anúncios que correspondam aos filtros informados
        /// </summary>
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<AdBasicModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Search([FromQuery] SearchAdModel filter)
        {
            var ads = await _service.SearchAdsAsync(keywordSearch: filter.KeywordSearch,
                                                    categories: filter.Categories,
                                                    order: (OrderSearchAd)filter.Order,
                                                    maxPrice: filter.MaxPrice,
                                                    minPrice: filter.MinPrice,
                                                    pageSize: filter.PageSize,
                                                    page: filter.Page);

            if (!ads.Any())
                return NoContent();

            return Ok(Map<List<AdBasicModel>>(ads));
        }

        /// <summary>
        /// Publica um novo anúncio
        /// </summary>
        /// <param name="adModel">Dados para publicação de um novo anúncio</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> PublishAd([FromBody] RegisterAdModel adModel)
        {
            var ad = Map<Ad>(adModel);
                        
            var result = await _service.PublishAdAsync(ad);

            if (!result.Sucess)
                return BadRequest(result.Errors);

            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Publica uma nova pergunta em um anúncio
        /// </summary>
        /// <param name="idAd">Identificador do anúncio</param>
        /// <param name="questionModel">Dados para publicação de uma nova pegunta</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("{idAd:guid}/ask")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Ask(Guid idAd, [FromBody] RegisterQuestionModel questionModel)
        {
            var result = await _service.AskAsync(idAd, Map<Question>(questionModel));

            if (!result.Sucess)
                return BadRequest(result.Errors);

            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Publica uma nova resposta para uma pergunta 
        /// </summary>
        /// <param name="idAd">Identificador do anúncio</param>
        /// <param name="idQuestion">Identificador da pergunta</param>
        /// <param name="responseModel">Dados de publicação de uma nova resposta</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("{idAd:guid}/question/{idQuestion:guid}/answer")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Answer(Guid idAd, Guid idQuestion, [FromBody] RegisterResponseModel responseModel)
        {
            responseModel.IdQuestion = idQuestion;

            var response = Map<Response>(responseModel);

            var result = await _service.AnswerAsync(idAd, response);

            if (!result.Sucess)
                return BadRequest(result.Errors);

            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Obtém os dados detalhados de um anúncio
        /// </summary>
        /// <param name="id">Identificador do anúncio</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(AdDetailedModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.Sucess)
                return NotFound(result.Errors);

            return Ok(Map<AdDetailedModel>(result.Value));
        }

        /// <summary>
        /// Obtém os anúncios mais recentes publicados
        /// </summary>
        /// <param name="number">Número máximo de anúncios</param>
        /// <returns></returns>
        [HttpGet]
        [Route("most-recent/{number:int:max(20)}")]
        [ProducesResponseType(typeof(List<AdBasicModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> MostRecentAsync(int number)
        {
            var ads = await _service.SearchAdsAsync(keywordSearch: "", pageSize: number);
            
            if (!ads.Any())
                return NoContent();

            return Ok(Map<List<AdBasicModel>>(ads));
        }
    }
}
