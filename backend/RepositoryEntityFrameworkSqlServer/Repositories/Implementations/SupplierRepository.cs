using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class SupplierRepository : BaseRepository<SupplierEntity, SupplierModel, int>, ISupplierRepositoryPort
    {
        public SupplierRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<SupplierModel> AddAsync(SupplierModel model) => SupplierMapper.ToDomain(await base.AddAsync(model));
    }
}
