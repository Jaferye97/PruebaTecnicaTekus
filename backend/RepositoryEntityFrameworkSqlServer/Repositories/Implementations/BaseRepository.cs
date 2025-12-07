using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositoryEntityFrameworkSqlServer.Entities.Constants;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public abstract class BaseRepository<TEntity, TModel, TPrimary> : IBaseRepository<TEntity, TModel, TPrimary>
    where TEntity : class, IEntity<TPrimary>
    where TModel : class
    {
        private readonly Func<TEntity, TModel> _toModel;
        private readonly Func<TModel, TEntity> _toEntity;

        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DbContext context, Func<TEntity, TModel> toModel, Func<TModel, TEntity> toEntity)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _toModel = toModel;
            _toEntity = toEntity;

            // Desactivar consulta con seguimiento
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual async Task<TModel?> GetAsync(TPrimary id)
        {
            return _toModel(await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id)));
        }

        public virtual async Task<List<TModel>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities.Select(_toModel).ToList();
        }

        public async Task<List<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids)
        {
            var entities = await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
            return entities.Select(_toModel).ToList();
        }

        public virtual async Task<TEntity> AddAsync(TModel model)
        {
            var entity = _toEntity(model);
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TModel> models)
        {
            var entities = models.Select(_toEntity);
            _dbSet.AddRange(entities);

            await _context.SaveChangesAsync();

            return entities;
        }

        public virtual async Task<TEntity> UpdateAsync(TModel model)
        {
            var entity = _toEntity(model);
            _context.Attach(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(IEnumerable<TModel> models)
        {
            foreach (var model in models)
            {
                var entity = _toEntity(model);
                _context.Attach(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TModel model)
        {
            var entity = _toEntity(model);
            _context.Attach(entity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<TModel> models)
        {
            foreach (var model in models)
            {
                var entity = _toEntity(model);
                _context.Attach(entity).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<TModel>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            return entities.Select(_toModel).ToList();
        }

        public async Task<List<TModel>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            var result = await query.ToListAsync().ConfigureAwait(false);
            return result.Select(_toModel).ToList();
        }

        public async Task<TModel> GetUniqueAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var list = await GetAsync(filter, orderBy, includes);
            return list.FirstOrDefault();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }
    }
}
