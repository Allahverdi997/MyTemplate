using Application.Abstraction.Core.App;
using Application.Abstraction.Core.Service.Other;
using Application.Abstraction.Core.UnitOfWork.Base;
using Application.Model.Response.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services.Other
{
    public class ExceptionNotificationService : IExceptionNotificationService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IAppSetting AppSetting { get; set; }
        public IAppSession AppSession { get; set; }
        public ExceptionNotificationService(IUnitOfWork unitOfWork, IAppSetting appSetting, IAppSession appSession)
        {
            UnitOfWork = unitOfWork;
            AppSetting = appSetting;
            AppSession = appSession;
        }
        public Content GetByKey(string key)
        {
            var exception = UnitOfWork.ExceptionNotificationReadRepository.FirstOrDefault(x => x.Key == key && x.LangId == AppSession.LangId);
            if (exception != null)
                return new Content(exception.Key, exception.Description);
            else
                return null;
        }
        public string GetDescription(string key)
        {
            var exception = UnitOfWork.ExceptionNotificationReadRepository.FirstOrDefault(x => x.Key == key && x.LangId == AppSession.LangId);
            if (exception != null)
                return exception.Description;
            else
                return null;
        }
    }
}
