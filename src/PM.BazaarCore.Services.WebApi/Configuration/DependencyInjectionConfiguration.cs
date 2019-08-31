using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PM.BazaarCore.Infrastructure.CrossCutting.IoC;

namespace PM.BazaarCore.Services.WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddBazaarServices(this IServiceCollection services, IConfiguration configuration)
        {
            BazaarContainer.RegisterServices(services, configuration);
        }
    }
}
