using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Contract.Repository;

namespace Todo.Repository.Infrastructure
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public Task<TEntity> FindAsync(params object[] key)
        {
            return _context.Set<TEntity>().FindAsync(key).AsTask();
        }

        public async Task<TEntity> GetAsync(params object[] key)
        {
            return await FindAsync(key) ?? throw new Exception("Entity not found");
        }

        public IQueryable<TEntity> Query() => Query(t => true);

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params object[] key)
        {
            var entity = _context.Set<TEntity>().Find(key);

            if (entity is { })
            {
                await DeleteAsync(entity);
            }
        }
    }
}