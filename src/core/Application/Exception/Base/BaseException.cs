using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exception.Base
{
    [Serializable]
    public class BaseException:System.Exception
    {
        public BaseException(int statusCode) : base()
        {
            StatusCode = statusCode;
        }
        public BaseException(string key, int statusCode) : base()
        {
            Key = key;
            StatusCode = statusCode;
        }
        public BaseException(string key, int statusCode, System.Exception exception,bool isKey) : base()
        {
            Key = key;
            StatusCode = statusCode;
            Exception = exception;
            IsKey = isKey;
        }
        public BaseException() : base()
        {

        }

        public bool IsKey { get; set; }
        public string Key { get; set; }
        public int StatusCode { get; set; }
        public System.Exception Exception { get; set; }
        public string Content { get; set; }
    }
}
