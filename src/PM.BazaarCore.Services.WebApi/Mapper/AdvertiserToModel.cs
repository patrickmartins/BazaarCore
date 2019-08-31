using AutoMapper;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Services.WebApi.Models;

namespace PM.BazaarCore.Services.WebApi.Mapper
{
    public class AdvertiserToModel : Profile
    {
        public AdvertiserToModel()
        {
            CreateMap<Advertiser, AdvertiserBasicModel>()
                .ForMember(c => c.Avatar, x => x.MapFrom(c => c.Avatar.Id));

            CreateMap<Advertiser, AdvertiserDetailedModel>()
                .ForMember(c => c.Avatar, x => x.MapFrom(c => c.Avatar.Id));
        }
    }
}
