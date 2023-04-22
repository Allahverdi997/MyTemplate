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
    public class NotificationLogReadRepository : NoSqlGenericReadRepository<Domain.Concrete.NoSql.Main.NotificationLog>, INotificationLogReadRepository
    {
        public NotificationLogReadRepository(INoSqlDbContext context) : base(context)
        {

        }
    }
}
