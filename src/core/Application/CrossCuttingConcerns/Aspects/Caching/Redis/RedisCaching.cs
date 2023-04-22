using Application.Abstraction.Core.Service.Other;
using Application.Abstraction.Core.UnitOfWork.Base;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Static.Tools;
using Application.Extension.Redis;
using AOPService.CrossCuttingConcerns.Interceptors;

namespace Application.CrossCuttingConcerns.Aspects.Caching.Redis
{
    public class RedisCaching : MethodInterceptor
    {
        public string Key { get; set; }
        public IDistributedCache RedisCache { get; set; }
        public Type Type { get; set; }
        public RedisCaching(string key,Type type)
        {
            RedisCache = ServiceTool.GetService<IDistributedCache>();
            Type = type;
            Key = key;
        }

        public override void Intercept(IInvocation invocation)
        {
            var result = RedisCache.GetRecord(Key,Type);
            if(result != null)
            {
                invocation.ReturnValue = result;
                return;
            }
            invocation.Proceed();
            RedisCache.SetRecordAsync(Key, Type,invocation.ReturnValue);
        }
    }
}
