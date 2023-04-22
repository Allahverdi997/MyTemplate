using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Static.Message
{
    public static class ExceptionMessage
    {
        public static string BadRequestException => "BadRequest Static";
        public static string ModelStateException => "Model State";
        public static string NotFoundException => "Not Found";
        public static string ServerErrorException => "Server Error";
        public static string SqlServerErrorException => "Sql Server Error";
        public static string UnAuthorizeException => "Don't Authorize";
        public static string KeyNotFoundException => "Key Not Found";
        public static string CommonException => "Common error occured";
        public static string FileSigningError => "FileSigning error occured";
    }
}
