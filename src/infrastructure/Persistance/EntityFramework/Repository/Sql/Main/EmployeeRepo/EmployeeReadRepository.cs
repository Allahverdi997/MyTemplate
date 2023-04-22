﻿using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.Sql.Main.EmployeeRepo;
using Domain.Concrete.Main;
using Persistance.Repository.Sql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Sql.Main.EmployeeRepo
{
    public class EmployeeReadRepository : SqlGenericReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
