using Application.Core.Repository.Main.ErrorLog;
using Application.Core.Repository.Main.NotificationLog;
using Application.Core.Repository.Main.WarningLog;
using Application.Core.UnitOfWork;
using Persistance.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UnitOfWork
{
    public sealed class NoSqlUnitOfWork : INoSqlUnitOfWork
    {
        private bool _isDisposed = false;
        private static bool setMongo = false;
        private readonly Dictionary<Type, object> _repositories;
        public MongoDbContext Context { get; set; }

        public NoSqlUnitOfWork(string connection,string database)
        {
            _repositories = new Dictionary<Type, object>();
            Context = new MongoDbContext(connection,database);
        }

        public IErrorLogReadRepository ErrorLogReadRepository => GetNoSqlRepository<IErrorLogReadRepository>();

        public IErrorLogWriteRepository ErrorLogWriteRepository => GetNoSqlRepository<IErrorLogWriteRepository>();

        public INotificationLogReadRepository NotificationLogReadRepository => GetNoSqlRepository<INotificationLogReadRepository>();

        public INotificationLogWriteRepository NotificationLogWriteRepository => GetNoSqlRepository<INotificationLogWriteRepository>();

        public IWarningLogReadRepository WarningLogReadRepository => GetNoSqlRepository<IWarningLogReadRepository>();

        public IWarningLogWriteRepository WarningLogWriteRepository => GetNoSqlRepository<IWarningLogWriteRepository>();


        internal TRepository GetNoSqlRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.GetExecutingAssembly().GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new KeyNotFoundException();

            var repository = (TRepository)Activator.CreateInstance(type, Context);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }
    }
}
