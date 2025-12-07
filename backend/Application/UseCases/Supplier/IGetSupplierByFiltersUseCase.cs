using Domain.Models.Commons;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier
{
    public interface IGetSupplierByFiltersUseCase
    {
        Task<PagedResult<SupplierModel>> ExecuteAsync(SupplierFilterModel filter);
    }
}
