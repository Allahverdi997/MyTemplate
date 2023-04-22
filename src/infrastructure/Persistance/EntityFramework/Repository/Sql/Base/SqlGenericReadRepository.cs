using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.Sql.Base;
using Domain.Concrete.Base;
using Microsoft.EntityFrameworkCore;
using Persistance.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Sql.Base
{
    public class SqlGenericReadRepository<T> : ISqlReadRepository<T> where T : BaseSqlEntityWithCreate
    {
        public ISqlDbContext Context;
        public SqlGenericReadRepository(ISqlDbContext context)
        {
            Context = context;
        }
        public DbSet<T> Table => Context.GetDbSet<T>();
        public IQueryable<T> AsQueryable => Table.AsQueryable();

        public void Attach(T entity)
        {
            Table.Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Table.AttachRange(entity);
        }

        public bool CheckExist(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return Table.Any();

            return Table.Any(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return Table.Count();

            return Table.Count(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> Get(int id, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (id != 0)
                query = AsQueryable.Where(x => x.Id == id);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAll(bool noTracking = false)
        {
            var query = AsQueryable;

            if (noTracking)
                query = query.AsNoTracking();

            return query;
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate = null, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query.SingleOrDefault();
        }

        #region Asenkron

        public async Task<bool> CheckExistAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await Table.AnyAsync();

            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await Table.CountAsync();

            return await Table.CountAsync(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = AsQueryable;

            if (predicate != null)
                query = AsQueryable.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();
        }
        #endregion

        private static IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes.Length != 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }
    }
}
