using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    internal class CommonException : BaseException
    {
        public CommonException() : base(001)
        {
            StatusCode = 400;
        }
        public CommonException(string key) : base(key, 400)
        {
            Key = key;
        }
        public CommonException(string key, System.Exception exception, bool isKey) : base(key, 400, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
