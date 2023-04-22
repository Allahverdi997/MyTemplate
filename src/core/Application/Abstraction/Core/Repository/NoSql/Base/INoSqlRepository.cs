using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.NoSql.Base
{
    public interface INoSqlRepository<T>
    {
        IMongoCollection<T> Table { get; }
    }
}
