using AspNetCoreRateLimit;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace School.Webapi.Extensions
{
    public static class RateLimitingExtensions
    {
        public static void ConfigureRateLimiting(
            this IServiceCollection services)
        {
            var rateLimits = new List<RateLimitRule> {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Limit = 1,
                        Period = "5s"
                    }
                };
            services.Configure<IpRateLimitOptions>(option =>
            {
                option.GeneralRules = rateLimits;
            });

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
