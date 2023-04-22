﻿using Application.Core.Repository.Base;
using Domain.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Repository.Main.NotificationLog
{
    public interface INotificationLogWriteRepository:INoSqlWriteRepository<NotificationLogs>
    {
    }
}
