using System.Linq.Expressions;

namespace RepositoryEntityFrameworkSqlServerV2.Repositories;

public interface IBaseRepository<TEntity, TModel, in TPrimary>
        where TEntity : class
        where TModel : class
{
    Task<TModel?> GetAsync(TPrimary id);

    Task<IReadOnlyList<TModel>> GetAllAsync();

    Task<IReadOnlyList<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids);

    Task<TEntity> AddAsync(TModel model);

    Task<IReadOnlyList<TEntity>> AddAsync(IEnumerable<TModel> models);

    Task<TEntity> UpdateAsync(TModel model);

    Task UpdateAsync(IEnumerable<TModel> models);

    Task DeleteAsync(TModel model);

    Task DeleteAsync(IEnumerable<TModel> models);

    Task<IReadOnlyList<TModel>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate);

    Task<IReadOnlyList<TModel>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TModel?> GetUniqueAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
}
