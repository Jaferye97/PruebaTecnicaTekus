using Domain.Models.Supplier;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Repositories
{
    public interface ISupplierAttributeRepository
    {
        Task<IEnumerable<SupplierAttributeEntity>> AddAsync(IEnumerable<SupplierAttributeModel> models);
        Task UpdateAsync(IEnumerable<SupplierAttributeModel> models);
    }
}
