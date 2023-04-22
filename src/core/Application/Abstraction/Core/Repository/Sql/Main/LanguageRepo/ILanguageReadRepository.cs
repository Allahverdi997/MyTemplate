using Application.Abstraction.Core.Repository.Sql.Base;
using Domain.Concrete.Sql.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.Sql.Main.LanguageRepo
{
    public interface ILanguageReadRepository : ISqlReadRepository<Language>
    {
    }
}
