using Domain.Models.Supplier;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class SupplierAttributeRepository : BaseRepository<SupplierAttributeEntity, SupplierAttributeModel, int>, ISupplierAttributeRepository
    {
        public SupplierAttributeRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {

        }
    }
}
