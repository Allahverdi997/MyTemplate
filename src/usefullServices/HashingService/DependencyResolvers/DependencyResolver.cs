using HashingService.Abstract;
using HashingService.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingService.DependencyResolvers
{
    public static class DependencyResolver
    {
        public static void HashingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHashService, HashService>();
            
        }
    }
}
