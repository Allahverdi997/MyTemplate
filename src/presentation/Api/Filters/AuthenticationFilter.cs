using Api.Attributes;
using Api.Enum;
using Api.Other;
using Application.Abstraction.Core.App;
using Application.Abstraction.Core.Service.Other;
using Application.Enum;
using Application.Exception.Base;
using Application.Model.Response.Data;
using Application.Model.Response.Main;
using Application.Static.Message;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private readonly IExceptionNotificationService ExceptionNotificationService;
        private readonly IAppSetting AppSettings;
        private readonly IFilterService FilterService;

        public AuthenticationFilter(IExceptionNotificationService exceptionNotificationService,
            IFilterService filterService,
            IAppSetting appSettings)
        {
            ExceptionNotificationService = exceptionNotificationService;
            AppSettings = appSettings;
            FilterService = filterService;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                HttpRequest request = context.HttpContext.Request;
                var lang = request.Headers["ExceprionLanguage"];
                FilterService.AddLanguage(lang.ToString());

                if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    var isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                        .Any(a => a.GetType().Equals(typeof(AnonymAttribute)));

                    if (isDefined)
                        return;
                }


                var authorization = request.Headers["AuthenticationToken"];

                FilterService.AuthenticateUser(authorization.ToString());
            }
            catch (System.Exception ex)
            {
                try
                {
                    string key = String.Empty;
                    HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
                    bool isKey = false;
                    var type = string.Empty;
                    if (ex.GetType().IsSubclassOf(typeof(BaseException)))
                    {
                        var exception = (BaseException)ex;
                        httpStatusCode = (HttpStatusCode)exception.StatusCode;
                        key = exception.Key;
                        isKey = exception.IsKey;
                        type = ex.GetType().Name;

                        if (isKey)
                            context.Result = CreateResponseResult.CreateHttpResponseMessage(httpStatusCode, new ErrorReponseModel<Exception>(new Error(ExceptionNotificationService.GetByKey(key), ex.Message)));
                        else
                            context.Result = CreateResponseResult.CreateHttpResponseMessage(httpStatusCode, new ErrorReponseModel<Exception>(new Error(new Content(type, key), ex.Message)));
                    }
                    else
                        context.Result = CreateResponseResult.CreateHttpResponseMessage(HttpStatusCode.BadRequest, new ErrorReponseModel<Exception>(new Error(new Content(ExceptionEnum.CommonException.ToString(), ExceptionMessage.CommonException), ex.Message)));

                }
                catch (Exception _ex)
                {
                    context.Result = CreateResponseResult.CreateHttpResponseMessage(HttpStatusCode.BadRequest, new ErrorReponseModel<Exception>(new Error(new Content(ExceptionEnum.CommonException.ToString(), ExceptionMessage.CommonException), _ex.Message)));
                }
            }

        }
    }
}
