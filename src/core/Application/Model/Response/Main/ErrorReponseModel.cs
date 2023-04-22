using Application.Model.Response.Base;
using Application.Model.Response.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response.Main
{
    public class ErrorReponseModel<T>:BaseResponseModel<T> where T : class
    {
        public ErrorReponseModel(Error error) : base(default(T), error, false)
        {
            Data = default(T);
            Error = error;
            Success = false;
        }
    }
}
