using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    public class SqlServerException : BaseException
    {
        public SqlServerException() : base(501)
        {
            StatusCode = 501;
        }
        public SqlServerException(string key) : base(key, 501)
        {
            Key = key;
        }
        public SqlServerException(string key, System.Exception exception, bool isKey) : base(key, 501, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
