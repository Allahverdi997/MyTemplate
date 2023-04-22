using Application.Abstraction.Core.Repository.Sql.Base;
using Domain.Concrete.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.Sql.Main.EmployeeRepo
{
    public interface IEmployeeWriteRepository : ISqlWriteRepository<Employee>
    {
    }
}
