using Application.Abstraction.Core.Repository.NoSql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.NoSql.Main.ErrorLog
{
    public interface IErrorLogReadRepository:INoSqlReadRepository<Domain.Concrete.NoSql.Main.ErrorLogs>
    {
    }
}
