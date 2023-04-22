using Application.Abstraction.Core.Service.Main;
using Application.Abstraction.Core.Service.Other;
using Infrastructure.Services;
using JWTService.DependencyResolvers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderService;
using MailSenderService.DependencyResolvers;

namespace Infrastructure.DependencyInjection.AspNet
{
    public static class DependencyResolver
    {
        public static void RegisterServicesFromInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IDepartmentService, DepartmentService>();

            services.JWTConfiguration(configuration);

            services.MailConfiguration(configuration);
        }
    }
}
