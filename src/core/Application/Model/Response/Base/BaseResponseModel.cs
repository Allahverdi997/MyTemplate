using Application.Model.Response.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response.Base
{
    public class BaseResponseModel<T> where T : class
    {
        public BaseResponseModel(T data, Error error, bool success)
        {
            Data = data;
            Error = error;
            Success = success;
        }

        public T Data { get; set; }
        public Error Error { get; set; }
        public bool Success { get; set; }
    }
}
