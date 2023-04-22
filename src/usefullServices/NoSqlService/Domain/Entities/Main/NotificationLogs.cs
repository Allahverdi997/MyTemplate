using Domain.Abstract;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Main
{
    public class NotificationLogs : BaseNoSqlEntity,INoSqlEntity
    {
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
