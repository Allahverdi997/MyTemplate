using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.Sql.Main.ExceptionNotificationRepo;
using Domain.Concrete.Main;
using Persistance.Repository.Sql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Sql.Main.ExceptionNotificationRepo
{
    public class ExceptionNotificationReadRepository : SqlGenericReadRepository<ExceptionNotification>, IExceptionNotificationReadRepository
    {
        public ExceptionNotificationReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
