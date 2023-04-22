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
using System.Transactions;
using AOPService.CrossCuttingConcerns.Interceptors;

namespace Application.CrossCuttingConcerns.Aspects.Logging
{
    public class EfTransaction : MethodInterceptor
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public Type Class { get; set; }
        public EfTransaction(Type _class)
        {
            Class = _class;
        }
        public override void OnBefore(IInvocation invocation)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    tran.Complete();
                }
                catch (SystemException ex)
                {
                    tran.Dispose();
                    UnitOfWork = UnitOfWork = ServiceTool.GetService<IUnitOfWork>();
                    UnitOfWork.ErrorLogWriteRepository.Add(new ErrorLogs() { Exception = ex, Message = ExceptionMessage.ServerErrorException, Type = typeof(System.Exception).Name, Class = Class.FullName, CreateDate = DateTime.Now, Data = invocation.Arguments, Method = invocation.Method.Name });
                    throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
                }
            }
        }
    }
}
