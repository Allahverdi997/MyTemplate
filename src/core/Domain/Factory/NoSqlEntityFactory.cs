using Domain.Abstract.Marker;
using Domain.Concrete.NoSql.Main;
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
        public static INoSqlEntity Get(this NoSqlEntityEnum @enum)
        {
            switch (@enum)
            {
                case NoSqlEntityEnum.ErrorLog:
                    return new ErrorLogs();
                    break;
                case NoSqlEntityEnum.NotificationLog:
                    return new NotificationLog();
                    break;
                case NoSqlEntityEnum.WarningLog:
                    return new WarningLog();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
