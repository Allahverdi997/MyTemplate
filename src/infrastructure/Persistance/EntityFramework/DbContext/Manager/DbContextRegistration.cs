using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DbContext.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DbContext.Manager
{
    public static class DbContextRegistration
    {
        public static void GenerateFromPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppSqlDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultSql"), b => b.MigrationsAssembly("Persistance"));
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
