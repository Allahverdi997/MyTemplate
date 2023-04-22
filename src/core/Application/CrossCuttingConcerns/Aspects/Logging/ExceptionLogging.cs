using Application.Abstraction.Core.UnitOfWork.Base;
using Application.Enum;
using Application.Exception.Main;
using Application.Static.Message;
using Application.Static.Tools;
using Castle.DynamicProxy;
using Domain.Concrete.NoSql.Main;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AOPService.CrossCuttingConcerns.Interceptors;

namespace Application.CrossCuttingConcerns.Aspects.Logging
{
    public class ExceptionLogging : MethodInterceptor
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public Type Class { get; set; }
        public ExceptionLogging(Type _class)
        {
            Class = _class;
        }
        public override void OnException(IInvocation invocation, System.Exception exception)
        {
            UnitOfWork = ServiceTool.GetService<IUnitOfWork>();
            UnitOfWork.ErrorLogWriteRepository.Add(new ErrorLogs() { Exception = exception, Message = ExceptionMessage.ServerErrorException, Type = exception.GetType().Name, Class = Class.FullName, CreateDate = DateTime.Now, Data = invocation.Arguments, Method = invocation.Method.Name });
            throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), exception, false);
        }

        public override void OnBefore(IInvocation invocation)
        {
            base.OnBefore(invocation);
        }


    }
}
