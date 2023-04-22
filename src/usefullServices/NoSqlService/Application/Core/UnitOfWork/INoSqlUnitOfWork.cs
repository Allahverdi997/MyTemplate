using Application.Core.Repository.Main.ErrorLog;
using Application.Core.Repository.Main.NotificationLog;
using Application.Core.Repository.Main.WarningLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.UnitOfWork
{
    public interface INoSqlUnitOfWork
    {

        IErrorLogReadRepository ErrorLogReadRepository { get; }
        IErrorLogWriteRepository ErrorLogWriteRepository { get; }
        INotificationLogReadRepository NotificationLogReadRepository { get; }
        INotificationLogWriteRepository NotificationLogWriteRepository { get; }
        IWarningLogReadRepository WarningLogReadRepository { get; }
        IWarningLogWriteRepository WarningLogWriteRepository { get; }
    }
}
