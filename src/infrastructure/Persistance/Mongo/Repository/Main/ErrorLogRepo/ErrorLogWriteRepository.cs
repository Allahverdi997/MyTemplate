using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Main.ErrorLog;
using Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Main.ErrorLogRepo
{
    public class ErrorLogWriteRepository : NoSqlGenericWriteRepository<Domain.Concrete.NoSql.Main.ErrorLogs>, IErrorLogWriteRepository
    {
        public ErrorLogWriteRepository(INoSqlDbContext context) : base(context)
        {

        }
    }
}
