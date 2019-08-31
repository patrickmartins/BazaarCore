using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Extensions;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt;
using PM.BazaarCore.Services.WebApi.Controllers.Common;
using PM.BazaarCore.Services.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BazaarCore.Services.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/account")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountApplicationService _service;

        public AccountController(IAccountApplicationService service, IMapper mapper, IHostingEnvironment env) : base(mapper, env)
        {
            _service = service;
        }


        /// <summary>
        /// Retorna as informações do usuário atualmente logado
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("me")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AdvertiserDetailedModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> MyAccount()
        {
            var result = await _service.GetByIdAsync(User.GetUserId());

            if (!result.Sucess)
                return NotFound(result.Errors);

            return Ok(Map<AdvertiserDetailedModel>(result.Value));
        }

        /// <summary>
        /// Cria uma nova conta de usuário
        /// </summary>
        /// <param name="accountModel">Dados de registro de um novo usuário</param>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Register([FromBody] RegisterAccountModel accountModel)
        {
            var account = Map<Account>(accountModel);
                       
            var result = await _service.CreateAccountAsync(account);

            if(!result.Sucess)
                return BadRequest(result.Errors);

            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Faz o login com usuário e senha informados
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="loginModel">Dados de login de um usuário</param>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(JwtToken), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromServices] IJwtAuthService authService, [FromBody] LoginModel loginModel)
        {
            var result = await authService.SignInAsync(loginModel.Email, loginModel.Password);

            if (!result.Sucess)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        /// <summary>
        /// Faz o logout do usuário atualmente logado
        /// </summary>
        [Authorize]
        [HttpGet]
        [Route("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Logout([FromServices] IJwtAuthService authService)
        {
            await authService.SignOutAsync();

            return Ok();
        }

        /// <summary>
        /// Altera a imagem de perfil do usuário atualmente logado
        /// </summary>
        /// <param name="idImage">Identificador da imagem</param>
        [HttpPost]
        [Authorize]
        [Route("change-avatar")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangeAvatar([FromBody] Guid idImage)
        {
            var result = await _service.ChangeAvatarAsync(User.GetUserId(), idImage);

            if (!result.Sucess)
                return BadRequest(result.Errors);

            return Ok();
        }

        /// <summary>
        /// Altera a senha de acesso do usuário atualmente logado
        /// </summary>
        /// <param name="passwordModel">Dados para troca de senha de um usuário</param>
        [HttpPost]
        [Authorize]
        [Route("change-password")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordModel passwordModel)
        {
            var result = await _service.ChangePasswordAsync(User.GetUserId(), passwordModel.CurrentPassword, passwordModel.Password);

            if (!result.Sucess)
                BadRequest(result.Errors);

            return Ok();
        }
    }
}
