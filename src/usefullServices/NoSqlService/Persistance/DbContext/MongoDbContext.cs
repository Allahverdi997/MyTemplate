using Domain.Abstract;
using Domain.Entities.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DbContext
{
    public class MongoDbContext
    {
        public readonly Dictionary<Type, object> DbCollections;
        public MongoClient Client { get; set; }
        public IConfiguration Configuration { get; set; }
        public IMongoDatabase Database { get; set; }
        public MongoDbContext(string connection, string database)
        {
            DbCollections = new Dictionary<Type, object>();

            if (Client == null)
                Client = new MongoClient(connection);


            if (Database == null)
                Database = Client.GetDatabase(database);
        }

        public IMongoCollection<T> GetCollection<T>() where T : class, INoSqlEntity
        {
            Type type = typeof(T);
            if (DbCollections.ContainsKey(typeof(T)))
                return (IMongoCollection<T>)DbCollections[typeof(T)];

            DbCollections.Add(typeof(T), Database.GetCollection<T>(type.Name.Trim()));

            return Database.GetCollection<T>(type.Name.Trim());
        }

        public void AddSaveChanges(BaseNoSqlEntity noSqlEntity)
        {
            noSqlEntity.IsActive = true;
            noSqlEntity.CreateDate = DateTime.Now;
        }

        public void UpdateSaveChanges(BaseNoSqlEntity noSqlEntity)
        {
            noSqlEntity.EditDate = DateTime.Now;
        }

    }
}
