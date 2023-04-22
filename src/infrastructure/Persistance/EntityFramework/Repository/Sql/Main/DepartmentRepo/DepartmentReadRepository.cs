using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.Sql.Main.DepartmentRepo;
using Domain.Concrete.Main;
using Persistance.Repository.Sql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Sql.Main.DepartmentRepo
{
    public class DepartmentReadRepository : SqlGenericReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
