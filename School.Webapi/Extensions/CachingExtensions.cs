using Microsoft.Extensions.DependencyInjection;

namespace School.Webapi.Extensions
{
    public static class CachingExtensions
    {
        public static void ConfigureHttpCacheHeaders(
            this IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddHttpCacheHeaders(
                    expiration => {
                        expiration.MaxAge = 120;
                        expiration.CacheLocation = 
                            Marvin.Cache.Headers.CacheLocation.Private;
                        },
                    validateOptions =>
                    {
                        validateOptions.MustRevalidate = true;
                    }
                 );

        }
    }
}
