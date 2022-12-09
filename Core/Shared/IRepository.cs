using System.Linq.Expressions;

namespace Core.Shared
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> GetRangeAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        void DeleteRange(IQueryable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
