using Application.Abstraction.Core.App;
using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Main.ErrorLog;
using Application.Abstraction.Core.Repository.NoSql.Main.NotificationLog;
using Application.Abstraction.Core.Repository.NoSql.Main.WarningLog;
using Application.Abstraction.Core.Repository.Sql.Main.DepartmentRepo;
using Application.Abstraction.Core.Repository.Sql.Main.EmployeeRepo;
using Application.Abstraction.Core.Repository.Sql.Main.ExceptionNotificationRepo;
using Application.Abstraction.Core.Repository.Sql.Main.LanguageRepo;
using Application.Abstraction.Core.Service.Main;
using Application.Abstraction.Core.Service.Other;
using Application.Abstraction.Core.UnitOfWork.Base;
using Application.App;
using Application.DependencyResolvers.Autofac;
using Application.Service.Other;
using Application.Static.Tools;
using JWTService.DependencyResolvers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistance.DbContext.Context;
using Persistance.DbContext.Manager;
using Persistance.Mongo.DbContext;
using Persistance.Mongo.Repository.Main.ErrorLogRepo;
using Persistance.Mongo.Repository.Main.NotificationRepo;
using Persistance.Mongo.Repository.Main.WarningRepo;
using Persistance.Repository.Sql.Main.DepartmentRepo;
using Persistance.Repository.Sql.Main.EmployeeRepo;
using Persistance.Repository.Sql.Main.ExceptionNotificationRepo;
using Persistance.Repository.Sql.Main.LanguageRepo;
using Persistance.Services;
using Persistance.Services.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DependencyResolvers.AspNet
{
    public static class DependencyResolver
    {
        public static void RegisterServicesFromPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServicesFromApplication(configuration);

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            services.AddScoped<IExceptionNotificationReadRepository, ExceptionNotificationReadRepository>();
            services.AddScoped<IExceptionNotificationWriteRepository, ExceptionNotificationWriteRepository>();

            services.AddScoped<IErrorLogReadRepository, ErrorLogReadRepository>();
            services.AddScoped<IErrorLogWriteRepository, ErrorLogWriteRepository>();

            services.AddScoped<INotificationLogReadRepository, NotificationLogReadRepository>();
            services.AddScoped<INotificationLogWriteRepository, NotificationLogWriteRepository>();

            services.AddScoped<IWarningLogReadRepository, WarningLogReadRepository>();
            services.AddScoped<IWarningLogWriteRepository, WarningLogWriteRepository>();

            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
            services.AddScoped<IWarningLogWriteRepository, WarningLogWriteRepository>();

            

            services.AddScoped<IUnitOfWork, UnitOfWork.Base.UnitOfWork>();

            services.AddScoped<IAppSession, AppSession>();
            services.AddScoped<IAppSetting, AppSetting>();
            services.AddScoped<IFilterService, FilterService>();

            services.AddScoped<INoSqlDbContext, MongoDbContext>();
            services.AddScoped<ISqlDbContext, AppSqlDbContext>();


            //services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IExceptionNotificationService, ExceptionNotificationService>();

            services.JWTConfiguration(configuration);

            services.GenerateFromPersistance(configuration);

            services.CreateServiceProvider();
        }
    }
}
