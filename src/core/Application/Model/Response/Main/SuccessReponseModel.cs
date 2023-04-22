using Application.Model.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response.Main
{
    public class SuccessReponseModel<T>:BaseResponseModel<T> where T : class
    {
        public SuccessReponseModel(T data):base(data,null,true)
        {
            Data = data;
            Error = null;
            Success = true;
        }
    }
}
