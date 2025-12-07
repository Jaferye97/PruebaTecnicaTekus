using Domain.Models.Service;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Repositories
{
    public interface IServiceCountryRepository
    {
        Task<IEnumerable<ServiceCountryEntity>> AddAsync(IEnumerable<ServiceCountryModel> models);
    }
}
