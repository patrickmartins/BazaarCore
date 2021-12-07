using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PM.BazaarCore.Infrastructure.CrossCutting.AspNetUtils.Filters;

namespace PM.BazaarCore.Services.WebApi.Configuration
{
    public static class MvcConfiguration
    {
        public static void AddMcv(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(c => c.SuppressModelStateInvalidFilter = true);

            services.AddMvc(c =>
            {
                c.Filters.Add(new InvalidModelFilter());
                c.Filters.Add(new AutoSetUserIdFilter());
            });
        }
    }
}
