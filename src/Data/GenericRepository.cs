using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Models;
using System.Linq.Expressions;

namespace PersonalExpenseTracker.Data
{
    public class GenericRepository<TEntity>
        : IGenericRepository<TEntity> where TEntity : BaseModel<Guid>
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query
                    .Where(x => !x.IsDeleted)
                    .Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
           Expression<Func<TEntity, bool>>? filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query
                    .Where(x => !x.IsDeleted)
                    .Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual TEntity? GetById(Guid id)
        {
            return dbSet
                .Where(x => !x.IsDeleted)
                .FirstOrDefault(x => x.Id == id);
        }

        public virtual async Task<TEntity>? GetByIdAsync(Guid id)
        {
            return await dbSet
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual void Insert(TEntity entity, Guid userId)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedBy = userId;
            entity.CreatedOn = DateTime.Now;

            dbSet.Add(entity);
        }

        public virtual void Delete(Guid id, Guid userId)
        {
            TEntity entityToDelete = GetById(id);
            entityToDelete.IsDeleted = true;

            Update(entityToDelete, userId);
        }

        public virtual void Update(TEntity entity, Guid userId)
        {
            var existingEntity = GetById(entity.Id);
            entity.CreatedBy = existingEntity.CreatedBy;
            entity.CreatedOn = existingEntity.CreatedOn;

            entity.UpdatedBy = userId;
            entity.UpdatedOn = DateTime.Now;

            var localEntities = dbSet
                .Local
                .Where(item => item.Id.Equals(entity.Id));

            if (localEntities != null && localEntities.Count() > 0)
            {
                foreach (var localEntity in localEntities)
                {
                    context.Entry(localEntity).State = EntityState.Detached;
                }
            }

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
