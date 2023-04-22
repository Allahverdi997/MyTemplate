using AOPService.CrossCuttingConcerns.Interceptors;
using Application.Abstraction.Core.Service.Other;
using Application.Abstraction.Core.UnitOfWork.Base;
using Application.Static.Tools;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Aspects.Caching.Microsoft
{
    public class MemoryCaching : MethodInterceptor
    {
        public Type Class { get; set; }
        public int Duration { get; set; }
        public MemoryCaching(Type _class,int duration=2)
        {
            Class = _class;
            Duration = duration;
        }

        public override void Intercept(IInvocation invocation)
        {
            string Key = Class.Name + invocation.Method.Name;
            IMemoryCacheService MemoryCache = ServiceTool.GetService<IMemoryCacheService>();
            var result = MemoryCache.Get(Key);
            if (result!=null)
            {
                invocation.ReturnValue = result;
                return;
            }
            invocation.Proceed();
            MemoryCache.Add(Key, invocation.ReturnValue, Duration);
        }

    }
}
