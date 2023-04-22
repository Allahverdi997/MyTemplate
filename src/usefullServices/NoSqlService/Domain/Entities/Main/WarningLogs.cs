using Domain.Abstract;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Main
{
    public class WarningLogs : BaseNoSqlEntity,INoSqlEntity
    {
        public string Class { get; set; }
        public string Method { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
