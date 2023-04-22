using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Static.Tools
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection CreateServiceProvider(this IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }

        public static T GetService<T>() where T :class
        {
            return ServiceProvider.GetService(typeof(T)) as T;
        }
    }
}
