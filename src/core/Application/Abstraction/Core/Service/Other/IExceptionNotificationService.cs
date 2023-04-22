using Application.Model.Response.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Service.Other
{
    public interface IExceptionNotificationService
    {
        Content GetByKey(string key);
        string GetDescription(string key);
    }
}
