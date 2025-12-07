using Domain.Models.Supplier;

namespace Application.UseCases.Supplier
{
    public interface IAddSupplierUseCase
    {
        Task<SupplierModel> ExecuteAsync(SupplierModel model);
    }
}
