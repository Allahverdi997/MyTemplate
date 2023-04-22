using Domain.Abstract.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Core.Repository.Sql.Base
{
    public interface ISqlReadRepository<T> : IRepository<T> where T : class, ISqlEntity
    {
        IQueryable<T> AsQueryable { get; }
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        T FirstOrDefault(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate = null, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(bool noTracking = false);
        IQueryable<T> Get(int id, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        T GetSingle(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        void Attach(T entity);
        void AttachRange(IEnumerable<T> entities);
        bool CheckExist(Expression<Func<T, bool>> predicate = null);
        int Count(Expression<Func<T, bool>> predicate = null);
        #region Asenkron
        Task<bool> CheckExistAsync(Expression<Func<T, bool>> predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = false, params Expression<Func<T, object>>[] includes);
        #endregion

    }
}
