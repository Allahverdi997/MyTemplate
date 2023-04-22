using Application.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Main
{
    [Serializable]
    public class ModelStateException : BaseException
    {
        public ModelStateException() : base(403)
        {
            StatusCode = 403;
        }
        public ModelStateException(string key) : base(key, 403)
        {
            Key = key;
        }
        public ModelStateException(string key, System.Exception exception, bool isKey) : base(key, 403, exception, isKey)
        {
            Key = key;
            Exception = exception;
            IsKey = isKey;
        }
    }
}
