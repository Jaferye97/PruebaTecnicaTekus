using System.Linq.Expressions;

namespace RepositoryEntityFrameworkSqlServer.Repositories
{
    public interface IBaseRepository<TEntity, TModel, in TPrimary>
        where TEntity : class
        where TModel : class
    {
        Task<TModel> GetAsync(TPrimary id);

        Task<List<TModel>> GetAllAsync();

        Task<List<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids);

        Task<TEntity> AddAsync(TModel model);

        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TModel> models);

        Task<TEntity> UpdateAsync(TModel model);

        Task UpdateAsync(IEnumerable<TModel> models);

        Task DeleteAsync(TModel model);

        Task DeleteAsync(IEnumerable<TModel> models);

        Task<List<TModel>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TModel>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TModel> GetUniqueAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
