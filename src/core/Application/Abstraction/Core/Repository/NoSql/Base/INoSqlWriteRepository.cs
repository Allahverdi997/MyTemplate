using Domain.Abstract.Marker;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.NoSql.Base
{
    public interface INoSqlWriteRepository<T> : INoSqlRepository<T> where T : class, INoSqlEntity
    {
        void Add(T entity);
        void Update(T entity, ObjectId id);
        void Delete(string id);
    }
}
