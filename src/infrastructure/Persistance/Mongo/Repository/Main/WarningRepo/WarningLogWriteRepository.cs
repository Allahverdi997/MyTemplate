using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Main.WarningLog;
using Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Main.WarningRepo
{
    public class WarningLogWriteRepository : NoSqlGenericWriteRepository<Domain.Concrete.NoSql.Main.WarningLog>, IWarningLogWriteRepository
    {
        public WarningLogWriteRepository(INoSqlDbContext context) : base(context)
        {

        }
    }
}
