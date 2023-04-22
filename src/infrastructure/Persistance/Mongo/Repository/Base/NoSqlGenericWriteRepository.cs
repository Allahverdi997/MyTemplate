using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Base;
using Domain.Abstract.Marker;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Base
{
    public class NoSqlGenericWriteRepository<T> : INoSqlWriteRepository<T> where T : class, INoSqlEntity
    {
        public INoSqlDbContext Context { get; set; }
        public NoSqlGenericWriteRepository(INoSqlDbContext context)
        {
            Context = context;
        }
        public IMongoCollection<T> Table => Context.GetCollection<T>();

        public void Add(T entity)
        {
            Table.InsertOne(entity);
        }

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            Table.DeleteOne(filter);
        }

        public void Update(T entity, ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            Table.ReplaceOne(filter, entity, new ReplaceOptions() { IsUpsert = true });
        }
    }
}
