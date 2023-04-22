using Application.Abstraction.Core.UnitOfWork.Base;
using Application.Enum;
using Application.Exception.Main;
using Application.Static.Message;
using Application.Static.Tools;
using Castle.DynamicProxy;
using Domain.Concrete.NoSql.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOPService.CrossCuttingConcerns.Interceptors; 

namespace Application.CrossCuttingConcerns.Aspects.Logging
{
    public class NotificationLogging : MethodInterceptor
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public Type Class { get; set; }
        public NotificationLogging(Type _class)
        {
            Class = _class;
        }

        public override void OnBefore(IInvocation invocation)
        {
            UnitOfWork = ServiceTool.GetService<IUnitOfWork>();
            UnitOfWork.NotificationLogWriteRepository.Add(new NotificationLog() { Message = NotificationMessage.NotificationBeginForFileSigning, Type = typeof(System.Exception).Name, Class = Class.FullName, CreateDate = DateTime.Now, Data = invocation.Arguments, Method = invocation.Method.Name });
        }
        public override void OnAfter(IInvocation invocation)
        {
            UnitOfWork = ServiceTool.GetService<IUnitOfWork>();
            UnitOfWork.NotificationLogWriteRepository.Add(new NotificationLog() { Message = NotificationMessage.NotificationEndForFileSigning, Type = typeof(System.Exception).Name, Class = Class.FullName, CreateDate = DateTime.Now, Data = invocation.Arguments, Method = invocation.Method.Name });
        }
        public override void OnSuccess(IInvocation invocation)
        {
            UnitOfWork = ServiceTool.GetService<IUnitOfWork>();
            UnitOfWork.NotificationLogWriteRepository.Add(new NotificationLog() { Message = NotificationMessage.NotificationSuccesForFileSigning, Type = typeof(System.Exception).Name, Class = Class.FullName, CreateDate = DateTime.Now, Data = invocation.Arguments, Method = invocation.Method.Name });
        }
        public override void OnException(IInvocation invocation, System.Exception exception)
        {
            UnitOfWork = ServiceTool.GetService<IUnitOfWork>();
            UnitOfWork.ErrorLogWriteRepository.Add(new ErrorLogs() { Exception = exception, Message = ExceptionMessage.ServerErrorException, Type = exception.GetType().Name, Class = Class.FullName, CreateDate = DateTime.Now, Data = invocation.Arguments, Method = invocation.Method.Name });
            throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), exception, false);
        }

    }
}
