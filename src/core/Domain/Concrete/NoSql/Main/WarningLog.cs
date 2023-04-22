using Domain.Abstract.Marker;
using Domain.Concrete.NoSql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.NoSql.Main
{
    public class WarningLog : BaseNoSqlEntity,INoSqlEntity
    {
        public string Class { get; set; }
        public string Method { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
