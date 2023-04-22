using Application.Abstraction.Core.App;
using Application.Abstraction.Core.Service.Other;
using Application.App;
using Application.Service.Other;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;

namespace Application.DependencyResolvers.Autofac
{
    public static class DependencyResolver
    {
        public static void RegisterServicesFromApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppSession, AppSession>();
            services.AddScoped<IAppSetting, AppSetting>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<IMemoryCacheService, MemoryCacheService>();

            var assm = Assembly.GetExecutingAssembly();

            var profiles = assm.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t)).ToList();

            var mappingConfig = new MapperConfiguration(a =>a.AddMaps(assm));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = "localhost:5002";
                opt.InstanceName = "RedisDemo_";
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    KeepAlive = 0,
                    AllowAdmin = true,
                    EndPoints = { { "127.0.0.1", 6379 } },
                    ConnectTimeout = 5000,
                    ConnectRetry = 5,
                    SyncTimeout = 5000,
                    AbortOnConnectFail = false,
                };
            });
        }
    }
}
