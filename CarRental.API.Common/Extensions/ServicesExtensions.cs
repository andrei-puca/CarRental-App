using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.API.Common.Extensions
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Auto register all services from the assembly as implemented interfaces
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        public static IServiceCollection RegisterAssemblyServices(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var service in types.Where(x => x.IsClass && !x.IsAbstract && x.FullName.EndsWith("Service", true, CultureInfo.InvariantCulture)))
            {
                services.AddTransientAsImplementedInterfaces(service);
            }

            return services;
        }

        /// <summary>
        /// Register type as implemented interfaces 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        internal static IServiceCollection AddTransientAsImplementedInterfaces(this IServiceCollection services, Type serviceType)
        {
            foreach (var interfaceType in serviceType.GetInterfaces())
            {
                services.AddTransient(interfaceType, serviceType);
            }

            return services;
        }
    }
}
