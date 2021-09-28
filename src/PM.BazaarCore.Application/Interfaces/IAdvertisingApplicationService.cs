using PM.BazaarCore.Application.Enuns;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BazaarCore.Application.Interfaces
{
    public interface IAdvertisingApplicationService
    {
        IEnumerable<Ad> SearchAds(string keywordSearch, Guid[] categories = default, 
                                            OrderSearchAd order = OrderSearchAd.Publish,
                                            double maxPrice = 0, double minPrice = 0,
                                            int pageSize = 20, int page = 1);

        Task<IEnumerable<Ad>> SearchAdsAsync(string keywordSearch, Guid[] categories = default,
                                            OrderSearchAd order = OrderSearchAd.Publish,
                                            double maxPrice = 0, double minPrice = 0,
                                            int pageSize = 20, int page = 1);

        IEnumerable<Ad> Page(int page, int pageSize);
        Task<IEnumerable<Ad>> PageAsync(int page, int pageSize);
        OperationResult<Ad> GetById(Guid id);
        Task<OperationResult<Ad>> GetByIdAsync(Guid id);
        OperationResult PublishAd(Ad ad);
        Task<OperationResult> PublishAdAsync(Ad ad);
        OperationResult RemoveAd(Guid id);
        Task<OperationResult> RemoveAdAsync(Guid id);
        OperationResult UpdateAd(Ad item);
        Task<OperationResult> UpdateAdAsync(Ad ad);
        OperationResult Ask(Guid idAd, Question question);
        Task<OperationResult> AskAsync(Guid idAd, Question question);
        OperationResult Answer(Guid idAd, Response response);
        Task<OperationResult> AnswerAsync(Guid idAd, Response response);
    }
}
