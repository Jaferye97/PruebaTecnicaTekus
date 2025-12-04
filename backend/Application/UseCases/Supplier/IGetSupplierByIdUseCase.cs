using Domain.Models.Supplier;

namespace Application.UseCases.Supplier
{
    public interface IGetSupplierByIdUseCase
    {
        Task<SupplierModel> ExecuteAsync(int id);
    }
}
