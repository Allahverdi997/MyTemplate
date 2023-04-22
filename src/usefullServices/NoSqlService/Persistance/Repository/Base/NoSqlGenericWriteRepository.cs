using Application.Core.Repository.Base;
using Domain.Abstract;
using Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.Repository.Base
{
    public class NoSqlGenericWriteRepository<T> : INoSqlWriteRepository<T> where T : class, INoSqlEntity
    {
        public MongoDbContext Context { get; set; }
        public NoSqlGenericWriteRepository(MongoDbContext context)
        {
            Context = context;
        }
        public IMongoCollection<T> Table => Context.GetCollection<T>();

        public void Add(T entity)
        {
            try
            {
                Context.AddSaveChanges(entity as BaseNoSqlEntity);
                Table.InsertOne(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(string id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                Table.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Update(T entity, ObjectId id)
        {
            try
            {
                Context.UpdateSaveChanges(entity as BaseNoSqlEntity);
                var filter = Builders<T>.Filter.Eq("_id", id);
                Table.ReplaceOne(filter, entity, new ReplaceOptions() { IsUpsert = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
