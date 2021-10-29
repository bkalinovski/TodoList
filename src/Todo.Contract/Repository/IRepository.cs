using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Todo.Contract.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> FindAsync(params object[] key);

        Task<TEntity> GetAsync(params object[] key);

        IQueryable<TEntity> Query();
        
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(params object[] key);
    }
}