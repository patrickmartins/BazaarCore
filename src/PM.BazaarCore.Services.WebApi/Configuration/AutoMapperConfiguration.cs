using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PM.BazaarCore.Services.WebApi.Mapper;
using System;

namespace PM.BazaarCore.Services.WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AccountToModel());
                config.AddProfile(new AdToModel());
                config.AddProfile(new QuestionToModel());
                config.AddProfile(new AdvertiserToModel());
                config.AddProfile(new ResponseToModel());
                config.AddProfile(new AdvertiserToModel());
                config.AddProfile(new CategoryToModel());

                config.ValueTransformers.Add<DateTime>(x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
            });
        }
    }
}
