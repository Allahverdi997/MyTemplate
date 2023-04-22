using Application.Core.Repository.Main.WarningLog;
using Domain.Entities.Main;
using Persistance.DbContext;
using Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Main.WarningRepo
{
    public class WarningLogReadRepository : NoSqlGenericReadRepository<WarningLogs>, IWarningLogReadRepository
    {
        public WarningLogReadRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
