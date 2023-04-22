using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.Sql.Main.LanguageRepo;
using Domain.Concrete.Sql.Main;
using Persistance.Repository.Sql.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Sql.Main.LanguageRepo
{
    public class LanguageReadRepository : SqlGenericReadRepository<Language>, ILanguageReadRepository
    {
        public LanguageReadRepository(ISqlDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
