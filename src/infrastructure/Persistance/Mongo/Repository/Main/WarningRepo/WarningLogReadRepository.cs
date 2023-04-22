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
    public class WarningLogReadRepository : NoSqlGenericReadRepository<Domain.Concrete.NoSql.Main.WarningLog>, IWarningLogReadRepository
    {
        public WarningLogReadRepository(INoSqlDbContext context) : base(context)
        {

        }
    }
}
