using Microsoft.Extensions.DependencyInjection;
using CarRental.API.Common.Extensions;
using CarRental.API.Common.SettingsOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.API.DAL.Infrastructure.Extensions
{
    public static class DIExtenstions
    {
        public static IServiceCollection RegisterApplicationDAL(this IServiceCollection services)
        {
            services.RegisterAssemblyServices(typeof(DIExtenstions).Assembly);
            return services;
        }
    }
}
