using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base(400)
        {
            StatusCode = 400;
        }
        public BadRequestException(string key) : base(key, 400)
        {
            Key = key;
        }
        public BadRequestException(string key, System.Exception exception,bool isKey) : base(key, 400, exception,isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
