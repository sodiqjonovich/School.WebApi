using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using School.Webapi.Data;
using School.Webapi.Entities.Models;

namespace School.Webapi.Extensions
{
    public static class IdentityServiceExtentions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(option => 
                                    option.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(
                builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
        }
    }
}
