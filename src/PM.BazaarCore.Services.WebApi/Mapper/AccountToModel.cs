using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Configuration;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Services.WebApi.Models;
using System;
using System.IO;

namespace PM.BazaarCore.Services.WebApi.Mapper
{
    public class AccountToModel : Profile
    {
        public AccountToModel()
        {            
            CreateMap<Account, AdvertiserDetailedModel>()
                .ForMember(c => c.Name, x => x.MapFrom(c => c.Advertiser.Name))
                .ForMember(c => c.LastName, x => x.MapFrom(c => c.Advertiser.LastName))
                .ForMember(c => c.Avatar, x => x.MapFrom(c => c.Advertiser.Avatar.Id));

            CreateMap<Account, AdvertiserBasicModel>()
                .ForMember(c => c.Name, x => x.MapFrom(c => c.Advertiser.Name))
                .ForMember(c => c.Avatar, x => x.MapFrom(c => c.Advertiser.Avatar.Id));

            CreateMap<RegisterAccountModel, Account>()
                .ConstructUsing((c, r) => new Account(c.Email, c.Password, new Advertiser(c.Id, c.Name, c.LastName, DateTime.Now, new Image(Guid.NewGuid(), GetDefaultImage((IHostingEnvironment)r.Items["env"])))))
                .ForAllMembers(c => c.Ignore());
        }

        private byte[] GetDefaultImage(IHostingEnvironment env)
        {
            return File.ReadAllBytes(Path.Combine(env.WebRootPath, Configs.DefaultAvatarUrl));
        }
    }
}
