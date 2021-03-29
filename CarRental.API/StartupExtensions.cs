using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarRental.API.BL.Infrastructure.Extensions;
using CarRental.API.Common.SettingsOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.API
{
    internal static class StartupExtensions
    {
        internal static void RegisterApplicationLayers(this IServiceCollection services)
        {
            services.RegisterApplicationBL();
        }

        internal static void RegisterApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //config app settings here
            services.Configure<DatabaseOptions>(configuration.GetSection("Data"));
            services.Configure<ApiOptions>(configuration.GetSection("Data"));
        }
    }
}
