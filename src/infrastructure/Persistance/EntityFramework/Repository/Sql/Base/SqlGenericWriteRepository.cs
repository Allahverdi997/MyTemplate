using Application.Abstraction.Core.DbContext;
using Application.Abstraction.Core.Repository.Sql.Base;
using Application.Enum;
using Application.Exception.Main;
using Application.Factory;
using Domain.Abstract.Marker;
using Microsoft.EntityFrameworkCore;
using Persistance.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository.Sql.Base
{
    public class SqlGenericWriteRepository<T> : ISqlWriteRepository<T> where T : class, ISqlEntity
    {
        public ISqlDbContext Context;
        public SqlGenericWriteRepository(ISqlDbContext context)
        {
            Context = context;
        }

        public DbSet<T> Table => Context.GetDbSet<T>();

        #region Insert
        public void Add(T entity)
        {
            try
            {
                this.Table.Add(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex,false);
            }
        }
        public async Task AddAsync(T entity)
        {
            try
            {
                await this.Table.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                this.Table.AddRange(entities);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await this.Table.AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }
        #endregion
        #region AddOrUpdate

        public void AddOrUpdate(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                    Add(entity);
                else
                    Update(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }

        public async Task AddOrUpdateAsync(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                    await AddAsync(entity);
                else
                    await UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }
        #endregion
        #region Delete
        public void Delete(T entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    this.Table.Attach(entity);

                this.Table.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public void Delete(int id)
        {
            try
            {
                var entity = this.Table.Find(id);
                Delete(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    this.Table.Attach(entity);

                this.Table.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await this.Table.FindAsync(id);
                await DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public void DeleteRange(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            try
            {
                IEnumerable<T> entities = this.Table.Where(expression).ToList();
                foreach (T entity in entities)
                    Delete(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task DeleteRangeAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            try
            {
                IEnumerable<T> entities = await this.Table.Where(expression).ToListAsync();
                foreach (T entity in entities)
                    await DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        #endregion
        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        #endregion
        #region Update

        public void Update(T entity)
        {
            try
            {
                this.Table.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                this.Table.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        #endregion
    }
}
