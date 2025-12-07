using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations
{
    public class AddSupplierUseCase : IAddSupplierUseCase
    {
        private readonly ISupplierRepositoryPort _repository;

        public AddSupplierUseCase(ISupplierRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<SupplierModel> ExecuteAsync(SupplierModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
