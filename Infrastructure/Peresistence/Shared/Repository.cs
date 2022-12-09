using Core.Shared;
using Infrastructure.Peresistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Peresistence.Shared
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<TEntity>();
        }

        protected IQueryable<TEntity> GetAsQueryable()
        {
            return dbSet.AsNoTracking();
        }

        public virtual Task<IQueryable<TEntity>> GetRangeAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return Task.FromResult(expression is null ? GetAsQueryable() : GetAsQueryable().Where(expression));
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await GetAsQueryable().SingleOrDefaultAsync(a => a.Id == id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            return (await dbSet.AddAsync(entity)).Entity;
        }

        public virtual Task<TEntity> DeleteAsync(TEntity entity)
        {
            return Task.FromResult(dbSet.Remove(entity).Entity);
        }

        public virtual void DeleteRange(IQueryable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(dbSet.Update(entity).Entity);
        }
    }
}
