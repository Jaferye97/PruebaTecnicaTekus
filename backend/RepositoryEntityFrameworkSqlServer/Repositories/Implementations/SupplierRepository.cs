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

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;

        public async Task<SupplierModel> AddAsync(SupplierModel model) => SupplierMapper.ToDomain(await base.AddAsync(model));

        public async Task<SupplierModel> GetAsync(int id)
        {
            var model = await base.GetUniqueAsync(
                filter: s => s.Id == id,
                includes: s => s.SupplierAttribute
            );

            return model;
        }
    }
}
