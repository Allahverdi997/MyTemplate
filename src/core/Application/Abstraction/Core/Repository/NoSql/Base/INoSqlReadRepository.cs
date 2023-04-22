using Domain.Abstract.Marker;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.NoSql.Base
{
    public interface INoSqlReadRepository<T> :INoSqlRepository<T> where T : class,INoSqlEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        T Get(ObjectId id);
        T Get(Expression<Func<T, bool>> expression);
    }
}
