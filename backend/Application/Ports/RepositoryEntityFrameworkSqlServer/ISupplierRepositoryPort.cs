using Domain.Models.Supplier;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface ISupplierRepositoryPort
    {
        Task<SupplierModel> AddAsync(SupplierModel model);
    }
}
