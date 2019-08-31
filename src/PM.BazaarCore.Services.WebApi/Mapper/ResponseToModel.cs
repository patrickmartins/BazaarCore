using AutoMapper;
using PM.BazaarCore.Domain.Entities;
using PM.BazaarCore.Services.WebApi.Models;
using System;

namespace PM.BazaarCore.Services.WebApi.Mapper
{
    public class ResponseToModel : Profile
    {
        public ResponseToModel()
        {
            CreateMap<Response, ResponseModel>();
            CreateMap<RegisterResponseModel, Response>()
                .ConstructUsing(c => new Response(c.IdQuestion, c.Description, DateTime.UtcNow, c.IdAdvertiser))
                .ForAllMembers(c => c.Ignore());
        }
    }
}
