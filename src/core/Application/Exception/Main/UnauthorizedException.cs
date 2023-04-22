using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(401)
        {
            StatusCode = 401;
        }
        public UnauthorizedException(string key) : base(key, 401)
        {
            Key = key;
        }
        public UnauthorizedException(string key, System.Exception exception, bool isKey) : base(key, 401, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
