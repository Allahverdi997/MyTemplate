using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    public class PermissionAccesException : BaseException
    {
        public PermissionAccesException() : base(404)
        {
            StatusCode = 404;
        }
        public PermissionAccesException(string key) : base(key, 404)
        {
            Key = key;
        }
        public PermissionAccesException(string key, System.Exception exception, bool isKey) : base(key, 404, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
