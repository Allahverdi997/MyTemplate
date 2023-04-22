using Application.Core.Repository.Main.NotificationLog;
using Domain.Entities.Main;
using Persistance.DbContext;
using Persistance.Mongo.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Main.NotificationRepo
{
    public class NotificationLogWriteRepository : NoSqlGenericWriteRepository<NotificationLogs>, INotificationLogWriteRepository
    {
        public NotificationLogWriteRepository(MongoDbContext context) : base(context)
        {

        }
    }
}
