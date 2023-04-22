using Domain.Abstract.Marker;
using Domain.Concrete.Main;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factory
{
    public static class SqlEntityFactory
    {
        public static ISqlEntity Get(this SqlEntityEnum @enum)
        {
            switch (@enum)
            {
                case SqlEntityEnum.Department:
                    return new Department();
                    break;
                case SqlEntityEnum.Employee:
                    return new Employee();
                    break;
                case SqlEntityEnum.ExceptionNotification:
                    return new ExceptionNotification();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
