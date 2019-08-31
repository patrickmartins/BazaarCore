using Microsoft.EntityFrameworkCore;
using PM.BazaarCore.Application.ApplicationServices.Common;
using PM.BazaarCore.Application.Enuns;
using PM.BazaarCore.Application.Extensions;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.ApplicationServices
{
    public class AdvertisingApplicationService : ApplicationService, IAdvertisingApplicationService
    {
        private readonly IAdvertisingService _adService;
        private readonly IImageService _imageService;

        private bool _disposed;

        public AdvertisingApplicationService(IAdvertisingService adService, IImageService imageService, IUoW uow, CancellationToken cancellationToken) : base(uow, cancellationToken)
        {
            _adService = adService;
            _imageService = imageService;
        }

        public AdvertisingApplicationService(IAdvertisingService adService, IImageService imageService, IUoW uow) : base(uow, CancellationToken.None) { }

        public IEnumerable<Ad> SearchAds(string keywordSearch, Guid[] categories = default(Guid[]), OrderSearchAd order = OrderSearchAd.Publish, double maxPrice = 0, double minPrice = 0, int pageSize = 20, int page = 1)
        {
            return Search(keywordSearch, categories, order, maxPrice, minPrice, pageSize, page).ToList();
        }

        public async Task<IEnumerable<Ad>> SearchAdsAsync(string keywordSearch, Guid[] categories = default(Guid[]), OrderSearchAd order = OrderSearchAd.Publish, double maxPrice = 0, double minPrice = 0, int pageSize = 20, int page = 1)
        {
            return await Search(keywordSearch, categories, order, maxPrice, minPrice, pageSize, page).ToListAsync(CancellationToken);
        }

        public IEnumerable<Ad> Page(int page, int pageSize)
        {
            return _adService.Set()
                        .Skip(pageSize * (page - 1))
                        .Take(pageSize).ToList();
        }

        public async Task<IEnumerable<Ad>> PageAsync(int page, int pageSize)
        {
            return  (await _adService.Set()
                        .Skip(pageSize * (page - 1))
                        .Take(pageSize).ToListAsync(CancellationToken));
        }

        public OperationResult<Ad> GetById(Guid id)
        {
            var result = new OperationResult<Ad>();

            var ad = _adService.GetById(id);

            if (ad.Sucess)
                result.SetValue(ad.Value);
            else
                result.AddErrors(ad.Errors);

            return result;
        }

        public async Task<OperationResult<Ad>> GetByIdAsync(Guid id)
        {
            var result = new OperationResult<Ad>();

            var ad = await _adService.GetByIdAsync(id, CancellationToken);

            if (ad.Sucess)
                result.SetValue(ad.Value);
            else
                result.AddErrors(ad.Errors);

            return result;
        }

        public OperationResult PublishAd(Ad ad)
        {
            BeginTransaction();
            
            var result = LinkImageToAd(ad);

            if (!result.Sucess)
                return result;

            result = _adService.PublishAd(ad);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> PublishAdAsync(Ad ad)
        {
            BeginTransaction();

            var result = await LinkImageToAdAsync(ad);

            if (!result.Sucess)
                return result;

            result = await _adService.PublishAdAsync(ad, CancellationToken);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public OperationResult RemoveAd(Guid id)
        {
            BeginTransaction();

            var resultAd = _adService.GetById(id);

            if (!resultAd.Sucess)
                return resultAd;

            var result = _adService.RemoveAd(resultAd.Value);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> RemoveAdAsync(Guid id)
        {
            BeginTransaction();

            var resultAd = await _adService.GetByIdAsync(id);

            if (!resultAd.Sucess)
                return resultAd;

            var result = _adService.RemoveAd(resultAd.Value);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public OperationResult UpdateAd(Ad ad)
        {
            BeginTransaction();

            var resultAd = _adService.GetById(ad.Id);

            if (!resultAd.Sucess)
                return resultAd;
            
            var result = _adService.UpdateAd(ad);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> UpdateAdAsync(Ad ad)
        {
            BeginTransaction();

            var resultAd = await _adService.GetByIdAsync(ad.Id);

            if (!resultAd.Sucess)
                return resultAd;

            var result = _adService.UpdateAd(ad);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public OperationResult Ask(Guid idAd, Question question)
        {
            BeginTransaction();

            var adResult = _adService.GetById(idAd);

            if (!adResult.Sucess)
                return adResult;

            var result = _adService.Ask(adResult.Value, question);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> AskAsync(Guid idAd, Question question)
        {
            BeginTransaction();

            var adResult = await _adService.GetByIdAsync(idAd, CancellationToken);

            if (!adResult.Sucess)
                return adResult;

            var result = _adService.Ask(adResult.Value, question);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        public OperationResult Answer(Guid idAd, Response response)
        {
            BeginTransaction();

            var adResult = _adService.GetById(idAd);

            if (!adResult.Sucess)
                return adResult;

            var result = _adService.Answer(adResult.Value, response);

            if (result.Sucess)
                Commit();

            return result;
        }

        public async Task<OperationResult> AnswerAsync(Guid idAd, Response response)
        {
            BeginTransaction();

            var adResult = await _adService.GetByIdAsync(idAd, CancellationToken);

            if (!adResult.Sucess)
                return adResult;

            var result = _adService.Answer(adResult.Value, response);

            if (result.Sucess)
                await CommitAsync();

            return result;
        }

        private OperationResult LinkImageToAd(Ad ad)
        {
            foreach (var picture in ad.Pictures)
            {
                var result = _imageService.GetById(picture.IdImage);

                if (!result.Sucess)
                    return result;

                picture.Image = result.Value;
            }

            return new OperationResult();
        }

        private async Task<OperationResult> LinkImageToAdAsync(Ad ad)
        {
            foreach (var picture in ad.Pictures)
            {
                var result = await _imageService.GetByIdAsync(picture.IdImage, CancellationToken);

                if (!result.Sucess)
                    return result;

                picture.Image = result.Value;
            }

            return new OperationResult();
        }

        private IQueryable<Ad> Search(string keywordSearch, Guid[] categories, OrderSearchAd order, double maxPrice, double minPrice, int pageSize, int page)
        {
            var specification = SpecificationAdQueryBuilder.MinPrice(minPrice);

            specification = maxPrice > 0 ? specification.MaxPrice(maxPrice) : specification;
            specification = !string.IsNullOrEmpty(keywordSearch) ? specification.WithKeywordInTitle(keywordSearch) : specification;
            specification = categories?.Length > 0 ? specification.WithCategory(categories) : specification;

            var result = _adService.Search(specification);

            switch (order)
            {
                case OrderSearchAd.Publish: result = result.OrderBy(c => c.Date); break;
                case OrderSearchAd.MaxPrice: result = result.OrderByDescending(c => c.Price); break;
                case OrderSearchAd.MinPrice: result = result.OrderBy(c => c.Price); break;
            }

            return result
                    .Skip(pageSize * ((page > 0 ? page : 1) - 1))
                    .Take(pageSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _imageService.Dispose();
                _adService.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
