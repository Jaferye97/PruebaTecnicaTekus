using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RepositoryEntityFrameworkSqlServerV2.Repositories.Implementations;

public abstract class BaseRepository<TEntity, TModel, TPrimary>
    (
        DbContext context,
        Func<TEntity, TModel> toModel,
        Func<TModel, TEntity> toEntity
    ) :
    IBaseRepository<TEntity, TModel, TPrimary>
        where TEntity : class, IEntity<TPrimary>
        where TModel : class
{
    private readonly Func<TEntity, TModel> _toModel = toModel;
    private readonly Func<TModel, TEntity> _toEntity = toEntity;

    protected readonly DbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    /* ======= GETTERS ========= */

    public virtual async Task<TModel?> GetAsync(TPrimary id)
    {
        var entity = await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id!.Equals(id));

        return entity is null ? null : _toModel(entity);
    }

    public async Task<IReadOnlyList<TModel>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        var entities = await query.ToListAsync();
        return entities.Select(_toModel).ToList();
    }

    public virtual async Task<IReadOnlyList<TModel>> GetAllAsync()
    {
        var entities = await _dbSet
            .AsNoTracking()
            .ToListAsync();

        return entities.Select(_toModel).ToList();
    }

    public async Task<IReadOnlyList<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids)
    {
        var entities = await _dbSet
            .AsNoTracking()
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();

        return entities.Select(_toModel).ToList();
    }

    public async Task<IReadOnlyList<TModel>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities.Select(_toModel).ToList();
    }

    public async Task<TModel?> GetUniqueAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (filter is not null)
            query = query.Where(filter);

        if (orderBy is not null)
            query = orderBy(query);

        var entity = await query.FirstOrDefaultAsync();
        return entity is null ? null : _toModel(entity);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    /* ======= COMMANDS ========  */

    public virtual async Task<TEntity> AddAsync(TModel model)
    {
        var entity = _toEntity(model);
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<IReadOnlyList<TEntity>> AddAsync(IEnumerable<TModel> models)
    {
        var entities = models.Select(_toEntity).ToList();
        await _dbSet.AddRangeAsync(entities);
        return entities;
    }

    public virtual Task<TEntity> UpdateAsync(TModel model)
    {
        var entity = _toEntity(model);
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(IEnumerable<TModel> models)
    {
        var entities = models.Select(_toEntity).ToList();
        _dbSet.UpdateRange(entities);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TModel model)
    {
        var entity = _toEntity(model);
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(IEnumerable<TModel> models)
    {
        var entities = models.Select(_toEntity).ToList();
        _dbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }
}
