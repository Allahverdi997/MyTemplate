using AOPService.CrossCuttingConcerns.Interceptors;
using Application.Abstraction.Core.App;
using Application.Exception.Main;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Aspects.SecurityAccess
{
    public class AccessSecure : MethodInterceptor
    {
        public List<string> Permissions { get; set; }
        public IAppSession AppSession { get; set; }
        public AccessSecure(string permissions)
        {
            Permissions = permissions.Split(",").ToList();
        }

        public override void Intercept(IInvocation invocation)
        {
            //var result = Permissions.Contains(AppSession.UserPermissions);
            //if (!result)
            //{
              //  throw new PermissionAccesException();
            //}
            invocation.Proceed();
        }

    }

}