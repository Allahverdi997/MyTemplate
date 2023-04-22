using Application.Core.Repository.Main.ErrorLog;
using Domain.Entities.Main;
using Persistance.DbContext;
using Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Main.ErrorLogRepo
{
    public class ErrorLogWriteRepository : NoSqlGenericWriteRepository<ErrorLogs>, IErrorLogWriteRepository
    {
        public ErrorLogWriteRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
