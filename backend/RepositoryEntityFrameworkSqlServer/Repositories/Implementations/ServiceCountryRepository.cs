using Domain.Models.Service;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class ServiceCountryRepository : BaseRepository<ServiceCountryEntity, ServiceCountryModel, int>, IServiceCountryRepository
    {
        public ServiceCountryRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }
    }
}
