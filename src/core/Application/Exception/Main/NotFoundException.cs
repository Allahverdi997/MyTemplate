using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base(404)
        {
            StatusCode = 404;
        }
        public NotFoundException(string key) : base(key, 404)
        {
            Key = key;
        }
        public NotFoundException(string key, System.Exception exception, bool isKey) : base(key, 404, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
