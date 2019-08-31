using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PM.BazaarCore.Application.ApplicationServices;
using PM.BazaarCore.Application.Interfaces;
using PM.BazaarCore.Domain.Core.Interfaces;
using PM.BazaarCore.Domain.Interfaces.Repositories;
using PM.BazaarCore.Domain.Interfaces.Services;
using PM.BazaarCore.Domain.Services;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Entities;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Globalization;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Interfaces;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Jwt;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Managers;
using PM.BazaarCore.Infrastructure.CrossCutting.Identity.Validators;
using PM.BazaarCore.Infrastructure.Data.Contexts;
using PM.BazaarCore.Infrastructure.Data.Repositories;
using PM.BazaarCore.Infrastructure.Data.UnitOfWork;
using System.Linq;
using System.Threading;

namespace PM.BazaarCore.Infrastructure.CrossCutting.IoC
{
    public static class BazaarContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BazaarCoreContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("BazaarCoreConnection"));
                options.UseLazyLoadingProxies();                
            });

            services.AddLogging(configure => configure.AddDebug().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Debug));

            services.AddIdentity<Account, Role>()
                    .AddErrorDescriber<ErrorDescriberPtBr>()
                    .AddUserValidator<AdvertiserIdentityValidator>()
                    .AddUserValidator<EmailFormatIdentityValidator>()
                    .AddUserValidator<EmailAlreadyUsedIdentityValidator>()
                    .AddUserValidator<EmailIsRequiredIdentityValidator>()
                    .AddUserValidator<EmailLengthIdentityValidator>()
                    .AddPasswordValidator<PasswordLengthIdentityValidator>()
                    .AddUserManager<AccountManager>()
                    .AddUserStore<AccountRepository>()
                    .AddRoleStore<RoleRepository>();

            services.Remove(services.First(c => c.ImplementationType == typeof(PasswordValidator<Account>)));
            services.Remove(services.First(c => c.ImplementationType == typeof(UserValidator<Account>)));

            services.AddScoped(typeof(CancellationToken), c => c.GetService<IHttpContextAccessor>().HttpContext.RequestAborted);

            services.AddScoped<IAdvertisingRepository, AdvertisingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddScoped<IAdvertisingApplicationService, AdvertisingApplicationService>();
            services.AddScoped<IAccountApplicationService, AccountApplicationService>();
            services.AddScoped<IImageApplicationService, ImageApplicationService>();
            services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();

            services.AddScoped<IAdvertisingService, AdvertisingService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IJwtAuthService, JwtAuthService>();

            services.AddScoped<IUoW, UoW>();
        }
    }
}
