using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class SupplierAttributeRepository : BaseRepository<SupplierAttributeEntity, SupplierAttributeModel, int>, ISupplierAttributeRepository, ISupplierAttributeRepositoryPort
    {
        public SupplierAttributeRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;
    }
}
