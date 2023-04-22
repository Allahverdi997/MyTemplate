using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Marker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DbContext.Context
{
    public class AppSqlDbContext : Microsoft.EntityFrameworkCore.DbContext, ISqlDbContext
    {
        public readonly Dictionary<Type, object> DbSets;
        public AppSqlDbContext(DbContextOptions options) : base(options)
        {
            DbSets = new Dictionary<Type, object>();
        }
        DbSet<T> ISqlDbContext.GetDbSet<T>()
        {
            if (DbSets.ContainsKey(typeof(T)))
                return (DbSet<T>)DbSets[typeof(T)];

            DbSets.Add(typeof(T), Set<T>());

            return Set<T>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), x => !x.IsInterface && !x.IsAbstract && typeof(IEntityConfig).IsAssignableFrom(x));
        }

        void ISqlDbContext.SaveChanges()
        {
            SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        EntityEntry ISqlDbContext.Entry<T>(T entity)
        {
            return Entry(entity);
        }

        public void DisposeContext()
        {
            Dispose();
        }
    }
}
