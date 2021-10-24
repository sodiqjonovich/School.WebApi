using Microsoft.Extensions.DependencyInjection;
using School.Webapi.Repasitories.EmployeeRepasitory;
using School.Webapi.Repasitories.GroupRepasitory;
using School.Webapi.Repasitories.InformationRepasitory;
using School.Webapi.Repasitories.NewRepasitory;
using School.Webapi.Repasitories.PupilRepasitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Webapi.Extensions
{
    public static class RepasitoryExtensions
    {
        public static void ConfigureRepasitories(
            this IServiceCollection services)
        {
            services.AddTransient<IGroupRepasitory, GroupRepasitory>();
            services.AddTransient<IEmployeeRepasitory, EmployeeRepasitory>();
            services.AddTransient<INewRepasitory, NewRepasitory>();
            services.AddTransient<IPupilRepasitory, PupilRepasitory>();
            services.AddTransient<IInformationRepasitory, InformationRepasitory>();
        }
    }
}
