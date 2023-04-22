using Application.Abstraction.Core.App;
using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.NoSql.Base;
using Application.Abstraction.Core.Repository.NoSql.Main.ErrorLog;
using Application.Abstraction.Core.Repository.NoSql.Main.NotificationLog;
using Application.Abstraction.Core.Repository.NoSql.Main.WarningLog;
using Application.Abstraction.Core.Repository.Sql.Main.DepartmentRepo;
using Application.Abstraction.Core.Repository.Sql.Main.EmployeeRepo;
using Application.Abstraction.Core.Repository.Sql.Main.ExceptionNotificationRepo;
using Application.Abstraction.Core.Repository.Sql.Main.LanguageRepo;
using Application.Abstraction.Core.UnitOfWork;
using Application.Abstraction.Core.UnitOfWork.Base;
using Application.CrossCuttingConcerns.Aspects.Logging;
using Application.Static.Message;
using Domain.Concrete.Base;
using Domain.Concrete.Sql.Base;
using Domain.Factory;
using JWTService.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.UnitOfWork.Base
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISqlDbContext _appDbContext;
        private bool _isDisposed = false;
        private readonly Dictionary<Type, object> _repositories;
        private readonly INoSqlDbContext NoSqlDbContext;
        public IJWTService JWTService { get; set; }

        public UnitOfWork(ISqlDbContext appSqlDbContext, INoSqlDbContext noSqlDbContext,
            ILoggerFactory loggerFactory,
            IAppSession appSession, IJWTService jWTService)
        {
            _repositories = new Dictionary<Type, object>();
            _appDbContext = appSqlDbContext;
            NoSqlDbContext = noSqlDbContext;
            JWTService = jWTService;
        }

        public IDepartmentReadRepository DepartmentReadRepository => GetRepository<IDepartmentReadRepository>();
        public IDepartmentWriteRepository DepartmentWriteRepository => GetRepository<IDepartmentWriteRepository>();
        public IEmployeeReadRepository EmployeeReadRepository => GetRepository<IEmployeeReadRepository>();
        public IEmployeeWriteRepository EmployeeWriteRepository => GetRepository<IEmployeeWriteRepository>();
        public IExceptionNotificationReadRepository ExceptionNotificationReadRepository => GetRepository<IExceptionNotificationReadRepository>();
        public IExceptionNotificationWriteRepository ExceptionNotificationWriteRepository => GetRepository<IExceptionNotificationWriteRepository>();

        public ILanguageReadRepository LanguageReadRepository => GetRepository<ILanguageReadRepository>();

        public IErrorLogReadRepository ErrorLogReadRepository => GetNoSqlRepository<IErrorLogReadRepository>();

        public IErrorLogWriteRepository ErrorLogWriteRepository => GetNoSqlRepository<IErrorLogWriteRepository>();

        public INotificationLogReadRepository NotificationLogReadRepository => GetNoSqlRepository<INotificationLogReadRepository>();

        public INotificationLogWriteRepository NotificationLogWriteRepository => GetNoSqlRepository<INotificationLogWriteRepository>();

        public IWarningLogReadRepository WarningLogReadRepository => GetNoSqlRepository<IWarningLogReadRepository>();

        public IWarningLogWriteRepository WarningLogWriteRepository => GetNoSqlRepository<IWarningLogWriteRepository>();
        private void CommitWithEditor(string token, EntityEntry entityEntry)
        {
            //User u=SqlEntityFactory.Get(Domain.Enum.SqlEntityEnum.User);

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("CreateDate").CurrentValue = DateTime.UtcNow;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    var id = Convert.ToInt32(JWTService.DegenerateToken(token, "Id").Value);

                    //u = UserRepository.Get(x => x.Id == id);
                }
                //entityEntry.Property("EditUser").CurrentValue = u.Id;
                entityEntry.Property("EditorId").IsModified = true;
                entityEntry.Property("EditDate").CurrentValue = DateTime.UtcNow;
                entityEntry.Property("EditDate").IsModified = true;

                entityEntry.Property("CreateDate").IsModified = false;
            }
        }

        [ExceptionLogging(typeof(UnitOfWork))]
        private void CommitWithUser(string token, EntityEntry entityEntry)
        {
            var id = Convert.ToInt32(JWTService.DegenerateToken(token, "Id").Value);

            //User u = UserRepository.Get(x => x.Id == id);

            //if (u != null)
            //{
            if (entityEntry.State == EntityState.Added)
            {
                //entityEntry.Property("CreateUser").CurrentValue = u.Id;
                entityEntry.Property("CreateDate").CurrentValue = DateTime.UtcNow;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                //entityEntry.Property("EditUser").CurrentValue = u.Id;
                entityEntry.Property("EditorId").IsModified = true;
                entityEntry.Property("EditDate").CurrentValue = DateTime.UtcNow;
                entityEntry.Property("EditDate").IsModified = true;

                entityEntry.Property("CreatorId").IsModified = false;
                entityEntry.Property("CreateDate").IsModified = false;
            }
            //}
        }

        public void Commit(string token = null)
        {
            var entityEntries = _appDbContext.ChangeTracker.Entries();
            foreach (var entityEntry in entityEntries)
            {
                entityEntry.Property("IsActive").CurrentValue = true;
                if (entityEntry.Entity.GetType().BaseType == typeof(BaseSqlEntity))
                    CommitWithEditor(token, entityEntry);
                else if (entityEntry.Entity.GetType().BaseType == typeof(BaseSqlEntityWithCreate))
                    CommitWithUser(token, entityEntry);
            }


            _appDbContext.SaveChanges();
            _appDbContext.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _appDbContext.DisposeContext();
                _isDisposed = true;
            }
        }


        internal TRepository GetRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.GetExecutingAssembly().GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new KeyNotFoundException(ExceptionMessage.KeyNotFoundException);

            var repository = (TRepository)Activator.CreateInstance(type, _appDbContext);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }

        internal TRepository GetNoSqlRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.GetExecutingAssembly().GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new KeyNotFoundException(ExceptionMessage.KeyNotFoundException);

            var repository = (TRepository)Activator.CreateInstance(type, NoSqlDbContext);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }

    }
}
