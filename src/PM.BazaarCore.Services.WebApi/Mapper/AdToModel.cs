using AutoMapper;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Services.WebApi.Models;
using System;
using System.Linq;

namespace PM.BazaarCore.Services.WebApi.Mapper
{
    public class AdToModel : Profile
    {
        private readonly Random _random = new Random();

        public AdToModel()
        {
            CreateMap<Ad, AdDetailedModel>()
                .ForMember(c => c.Pictures, x => x.MapFrom(c => c.Pictures.Select(y => y.IdImage)));

            CreateMap<Ad, AdBasicModel>()
                .ForMember(c => c.Picture, x => x.MapFrom(c => c.Pictures.ElementAt(_random.Next(c.Pictures.Count-1)).IdImage));

            CreateMap<RegisterAdModel, Ad>()
                .ConstructUsing(c => new Ad(c.Id, c.Title, c.Description, DateTime.UtcNow, c.IdCategory, c.Price, c.IdAdvertiser))
                .AfterMap((source, origin) => source.Pictures.ToList().ForEach(c => origin.AddPicture(new AdImage(new Image(c, new byte[1]), origin))))
                .ForAllMembers(c => c.Ignore());
        }
    }
}
