using Application.Abstraction.Core.Repository.NoSql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.NoSql.Main.WarningLog
{
    public interface IWarningLogReadRepository : INoSqlReadRepository<Domain.Concrete.NoSql.Main.WarningLog>
    {
    }
}
