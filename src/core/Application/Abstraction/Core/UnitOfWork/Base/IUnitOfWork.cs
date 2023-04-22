using Application.Abstraction.Core.Repository.NoSql.Main.ErrorLog;
using Application.Abstraction.Core.Repository.NoSql.Main.NotificationLog;
using Application.Abstraction.Core.Repository.NoSql.Main.WarningLog;
using Application.Abstraction.Core.Repository.Sql.Main.DepartmentRepo;
using Application.Abstraction.Core.Repository.Sql.Main.EmployeeRepo;
using Application.Abstraction.Core.Repository.Sql.Main.ExceptionNotificationRepo;
using Application.Abstraction.Core.Repository.Sql.Main.LanguageRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.UnitOfWork.Base
{
    public interface IUnitOfWork
    {
        IDepartmentReadRepository DepartmentReadRepository { get; }
        IDepartmentWriteRepository DepartmentWriteRepository { get; }
        IEmployeeReadRepository EmployeeReadRepository { get; }
        IEmployeeWriteRepository EmployeeWriteRepository { get; }
        IExceptionNotificationReadRepository ExceptionNotificationReadRepository { get; }
        IExceptionNotificationWriteRepository ExceptionNotificationWriteRepository { get; }
        ILanguageReadRepository LanguageReadRepository { get; }

        IErrorLogReadRepository ErrorLogReadRepository { get; }
        IErrorLogWriteRepository ErrorLogWriteRepository { get; }
        INotificationLogReadRepository NotificationLogReadRepository { get; }
        INotificationLogWriteRepository NotificationLogWriteRepository { get; }
        IWarningLogReadRepository WarningLogReadRepository { get; }
        IWarningLogWriteRepository WarningLogWriteRepository { get; }

        void Commit(string token=null);
    }
}
