using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    public class ServerErrorException : BaseException
    {
        public ServerErrorException() : base(500)
        {
            StatusCode = 500;
        }
        public ServerErrorException(string key) : base(key, 500)
        {
            Key = key;
        }
        public ServerErrorException(string key, System.Exception exception, bool isKey) : base(key, 500, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
