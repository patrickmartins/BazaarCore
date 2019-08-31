using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PM.Bazaar.Services.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageApplicationService _service;
        public ImageController(IImageApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtém uma imagem publicada
        /// </summary>
        /// <param name="id">Identificador da imagem</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.Sucess)
                return NotFound(result.Errors);

            return File(result.Value.Bytes, "image/png");
        }

        /// <summary>
        /// Faz o upload de um nova imagem de perfil de usuário
        /// </summary>
        /// <param name="file">Arquivo de imagem</param>
        /// <returns>Identificador da nova imagem</returns>
        [HttpPost]
        [Authorize]
        [Route("upload-avatar")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> SaveAvatarAsync(IFormFile file)
        {            
            return await SaveImageAsync(file, int.Parse(Configs.MaxWidthAvatar), int.Parse(Configs.MaxHeightAvatar));
        }

        /// <summary>
        /// Faz o upload de um nova imagem de anúncio
        /// </summary>
        /// <param name="file">Arquivo de imagem</param>
        /// <returns>Identificador da nova imagem</returns>
        [HttpPost]
        [Authorize]
        [Route("upload-picture-ad")]
        [ProducesResponseType(typeof(List<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> SavePictureAsync(IFormFile file)
        {
            return await SaveImageAsync(file, int.Parse(Configs.MaxWidthPictureAd), int.Parse(Configs.MaxHeightPictureAd));
        }

        private async Task<ActionResult> SaveImageAsync(IFormFile file, int maxWidth, int maxHeight)
        {
            var id = Guid.NewGuid();

            using (Image<Rgba32> image = Image.Load(file.OpenReadStream()))
            {
                var stream = new MemoryStream();

                var ratioX = (double)maxWidth / image.Width;
                var ratioY = (double)maxHeight / image.Height;

                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                image.Mutate(ctx => ctx.Resize(newWidth, newHeight));
                image.SaveAsPng(stream);

                var result = await _service.SaveImageAsync(new BazaarCore.Domain.Entities.Image(id,stream.ToArray()));

                if (!result.Sucess)
                    return BadRequest(result.Errors);
            }

            return Created(string.Empty, id);
        }
    }
}
