using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Repositories
{
    public interface ICountryRepository
    {
        Task<List<CountryEntity>> AddAsync(List<CountryEntity> entities);
    }
}
