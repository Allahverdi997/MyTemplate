using Api.Enum;
using Api.Other;
using Application.Abstraction.Core.App;
using Application.Abstraction.Core.Service.Other;
using Application.Enum;
using Application.Exception.Base;
using Application.Model.Response.Data;
using Application.Model.Response.Main;
using Application.Static.Message;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filters
{
    public class UnhandledExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionNotificationService ExceptionNotificationService;
        private readonly IAppSetting AppSettings;
        private readonly IFilterService FilterService;

        public UnhandledExceptionFilter(IExceptionNotificationService exceptionNotificationService,
            IFilterService filterService,
            IAppSetting appSettings)
        {
            ExceptionNotificationService = exceptionNotificationService;
            AppSettings = appSettings;
            FilterService = filterService;
        }

        public void OnException(ExceptionContext context)
        {
            object obj = null;
            try
            {
                string key = String.Empty;
                HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
                bool isKey = false;
                var type = context.Exception.GetType().Name;
                if (context.Exception.GetType().IsSubclassOf(typeof(BaseException)))
                {
                    var exception = (BaseException)context.Exception;
                    httpStatusCode = (HttpStatusCode)exception.StatusCode;
                    key = exception.Key;
                    isKey = exception.IsKey;
                    type = context.Exception.GetType().Name;

                    if (isKey)
                        obj = new ErrorReponseModel<Exception>(new Error(ExceptionNotificationService.GetByKey(key), context.Exception.Message));
                    else
                        obj = new ErrorReponseModel<Exception>(new Error(new Content(type, key), context.Exception.Message));
                        

                }
                else
                    obj= new ErrorReponseModel<Exception>(new Error(new Content(ExceptionEnum.CommonException.ToString(), ExceptionMessage.CommonException), context.Exception.Message));
            }
            catch (Exception ex)
            {
                obj = new ErrorReponseModel<Exception>(new Error(new Content(ExceptionEnum.CommonException.ToString(), ExceptionMessage.CommonException), context.Exception.Message));
            }
            finally
            {
                context.Result = CreateResponseResult.CreateHttpResponseMessage(HttpStatusCode.BadRequest, obj);
            }
            
        }
    }
}
