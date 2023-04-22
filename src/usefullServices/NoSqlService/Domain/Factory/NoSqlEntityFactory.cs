using Domain.Abstract;
using Domain.Entities.Base;
using Domain.Entities.Main;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factory
{
    public static class NoSqlEntityFactory
    {
        public static BaseNoSqlEntity Get(this NoSqlEntityEnum @enum)
        {
            switch (@enum)
            {
                case NoSqlEntityEnum.ErrorLog:
                    return new ErrorLogs();
                    break;
                case NoSqlEntityEnum.NotificationLog:
                    return new NotificationLogs();
                    break;
                case NoSqlEntityEnum.WarningLog:
                    return new WarningLogs();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
