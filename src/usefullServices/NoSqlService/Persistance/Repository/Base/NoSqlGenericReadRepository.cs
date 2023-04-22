using Application.Core.Repository.Base;
using Domain.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.DbContext;
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
        public MongoDbContext Context { get; set; }
        public NoSqlGenericReadRepository(MongoDbContext context)
        {
            Context = context;
        }
        public IMongoCollection<T> Table => Context.GetCollection<T>();

        public T Get(ObjectId id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", id);
                return Table.Find(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            try
            {
                return Table.Find(expression).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return Table.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                return Table.Find(expression).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
