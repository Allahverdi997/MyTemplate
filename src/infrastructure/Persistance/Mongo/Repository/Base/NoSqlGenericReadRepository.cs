using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Base;
using Domain.Abstract.Marker;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Mongo.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Base
{
    public class NoSqlGenericReadRepository<T> : INoSqlReadRepository<T> where T : class, INoSqlEntity
    {
        public INoSqlDbContext Context { get; set; }
        public NoSqlGenericReadRepository(INoSqlDbContext context)
        {
            Context = context;
        }
        public IMongoCollection<T> Table => Context.GetCollection<T>();

        public T Get(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return Table.Find(filter).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return Table.Find(expression).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Table.AsQueryable().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return Table.Find(expression).ToList();
        }
    }
}
