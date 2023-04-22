using Application.Abstraction.Core.App;
using Application.Abstraction.Core.DbContext;
using Domain.Abstract.Marker;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Mongo.DbContext
{
    public class MongoDbContext:INoSqlDbContext
    {
        public readonly Dictionary<Type, object> DbCollections;
        public MongoClient Client { get; set; }
        public IConfiguration Configuration { get; set; }
        public IMongoDatabase Database { get; set; }
        public IAppSetting AppSetting { get; set; }
        public MongoDbContext(IConfiguration configuration,IAppSetting appSetting)
        {
            DbCollections = new Dictionary<Type, object>();
            Configuration = configuration;
            AppSetting = appSetting;

            if(Client==null)
                Client = new MongoClient(configuration.GetConnectionString("DefaultNoSql"));

            if (Database == null)
                Database = Client.GetDatabase(AppSetting.MongoDatabase);
        }

        public IMongoCollection<T> GetCollection<T>() where T : class,INoSqlEntity
        {
            Type type = typeof(T);
            if (DbCollections.ContainsKey(typeof(T)))
                return (IMongoCollection<T>)DbCollections[typeof(T)];

            DbCollections.Add(typeof(T), Database.GetCollection<T>(type.Name.Trim()));

            return Database.GetCollection<T>(type.Name.Trim());
        }
    }
}
