using Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exception.Main;
using Application.Exception.Base;

namespace Application.Factory
{
    public static class ExceptionFactory
    {
        //public static void ThrowException(this ExceptionEnum @enum, string key, System.Exception exception)
        //{
        //    if (!string.IsNullOrEmpty(key))
        //    {
        //        switch (@enum)
        //        {
        //            case ExceptionEnum.BadRequestException:
        //                throw new BadRequestException(key);
        //            case ExceptionEnum.ModelStateException:
        //                throw new ModelStateException(key);
        //            case ExceptionEnum.NotFoundException:
        //                throw new NotFoundException(key);
        //            case ExceptionEnum.ServerErrorException:
        //                throw new ServerErrorException(key);
        //            case ExceptionEnum.SqlServerException:
        //                throw new SqlServerException(key);
        //            case ExceptionEnum.UnauthorizedException:
        //                throw new UnauthorizedException(key);
        //            default:
        //                throw new System.Exception(key);
        //        }
        //    }

        //}
    }
}
