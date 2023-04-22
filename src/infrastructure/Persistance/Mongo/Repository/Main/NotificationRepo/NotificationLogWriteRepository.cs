using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Main.NotificationLog;
using Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Main.NotificationRepo
{
    public class NotificationLogWriteRepository : NoSqlGenericWriteRepository<Domain.Concrete.NoSql.Main.NotificationLog>, INotificationLogWriteRepository
    {
        public NotificationLogWriteRepository(INoSqlDbContext context) : base(context)
        {

        }
    }
}
