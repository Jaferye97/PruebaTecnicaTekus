using Domain.Models.Supplier;

namespace Application.UseCases.Supplier
{
    public interface IUpdateSupplierUseCase
    {
        Task<bool> ExecuteAsync(SupplierModel model);
    }
}
