using PersonalExpenseTracker.Models;
using System.Linq.Expressions;

namespace PersonalExpenseTracker.Data
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel<Guid>
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        TEntity? GetById(Guid id);

        Task<TEntity>? GetByIdAsync(Guid id);

        void Insert(TEntity entity, Guid userId);

        void Delete(Guid id, Guid userId);

        void Update(TEntity entity, Guid userId);
    }
}
