using Domain.Models.Supplier;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface ISupplierAttributeRepositoryPort
    {
        Task<SupplierAttributeModel> GetAsync(int id);
        Task DeleteAsync(SupplierAttributeModel model);
        Task<bool> ExistRecordAsync(int id);
    }
}
