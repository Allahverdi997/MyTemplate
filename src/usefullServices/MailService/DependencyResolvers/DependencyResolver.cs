using MailSenderService.Abstract;
using MailSenderService.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderService.DependencyResolvers
{
    public static class DependencyResolver
    {
        public static void MailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMailSenderService, MailSender>();
        }
    }
}
