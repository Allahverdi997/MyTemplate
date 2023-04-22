using AOPService.CrossCuttingConcerns.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

        }
    }
}
