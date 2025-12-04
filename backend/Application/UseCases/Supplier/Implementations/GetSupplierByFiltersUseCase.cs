using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Commons;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations
{
    public class GetSupplierByFiltersUseCase : IGetSupplierByFiltersUseCase
    {
        private readonly ISupplierRepositoryPort _repository;

        public GetSupplierByFiltersUseCase(ISupplierRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<SupplierModel>> ExecuteAsync(SupplierFilterModel filter)
        {
            return await _repository.GetAllAsync(filter);
        }
    }
}
