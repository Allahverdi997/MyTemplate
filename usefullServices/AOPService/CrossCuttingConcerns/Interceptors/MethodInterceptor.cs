using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPService.CrossCuttingConcerns.Interceptors
{
    public abstract class MethodInterceptor:MethodInterceptorBaseAttribute
    {
        public virtual void OnBefore(IInvocation invocation) { }
        public virtual void OnAfter(IInvocation invocation) { }
        public virtual void OnException(IInvocation invocation,Exception exception) { }
        public virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                OnSuccess(invocation);
                OnAfter(invocation);
            }
            catch (Exception ex)
            {
                OnException(invocation,ex);
                throw;
            }
            
        }

    }
}
