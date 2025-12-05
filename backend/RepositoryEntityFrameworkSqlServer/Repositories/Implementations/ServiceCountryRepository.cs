using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Service;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class ServiceCountryRepository : BaseRepository<ServiceCountryEntity, ServiceCountryModel, int>, IServiceCountryRepository, IServiceCountryRepositoryPort
    {
        public ServiceCountryRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;
    }
}
