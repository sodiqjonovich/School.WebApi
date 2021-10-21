using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Webapi.Services.AuthorizeManager;

namespace School.Webapi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddTransient<IAuthManager, AuthManager>();
        }
    }
}
