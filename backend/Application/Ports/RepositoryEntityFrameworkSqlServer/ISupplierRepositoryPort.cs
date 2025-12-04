using Domain.Models.Commons;
using Domain.Models.Supplier;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface ISupplierRepositoryPort
    {
        Task<bool> ExistRecordAsync(int id);
        Task<SupplierModel> AddAsync(SupplierModel model);
        Task<SupplierModel> GetAsync(int id);
        Task<bool> UpdateAsync(SupplierModel model);
        Task<PagedResult<SupplierModel>> GetAllAsync(SupplierFilterModel filter);
    }
}
