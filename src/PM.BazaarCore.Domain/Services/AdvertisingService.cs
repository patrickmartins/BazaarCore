using PM.BazaarCore.Domain.Core.Services;
using PM.BazaarCore.Domain.Core.Values;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Domain.Interfaces.Repositories;
using PM.BazaarCore.Domain.Interfaces.Services;
using PM.BazaarCore.Domain.Validations.Ad;
using System.Threading;
using System.Threading.Tasks;

namespace PM.BazaarCore.Domain.Services
{
    public class AdvertisingService : Service<Ad>, IAdvertisingService
    {
        private readonly ICategoryRepository _categoryRepository;

        public AdvertisingService(IAdvertisingRepository adRepository, ICategoryRepository categoryRepository) : base(adRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public OperationResult PublishAd(Ad item)
        {
            var result = new CategoryExistValidation(_categoryRepository).IsValid(item);
            
            if(result.Sucess)
                return Insert(item);

            return new OperationResult(result.Errors);
        }

        public async Task<OperationResult> PublishAdAsync(Ad ad, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = new CategoryExistValidation(_categoryRepository).IsValid(ad);

            if (result.Sucess)
                return await InsertAsync(ad);

            return new OperationResult(result.Errors);
        }

        public OperationResult RemoveAd(Ad ad)
        {
            return Remove(ad);
        }

        public OperationResult UpdateAd(Ad ad)
        {
            return Update(ad);
        }

        public OperationResult Ask(Ad ad, Question question)
        {
            var result = ad.Ask(question);

            if (!result.Sucess)
                return result;

            return Update(ad);
        }

        public OperationResult Answer(Ad ad, Response response)
        {
            var result = ad.Answer(response);

            if (!result.Sucess)
                return result;

            return Update(ad);
        }
    }
}
