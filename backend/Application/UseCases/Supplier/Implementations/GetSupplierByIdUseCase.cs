using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations
{
    public class GetSupplierByIdUseCase : IGetSupplierByIdUseCase
    {
        private readonly ISupplierRepositoryPort _repository;

        public GetSupplierByIdUseCase(ISupplierRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<SupplierModel?> ExecuteAsync(int id)
        {
            if (!await _repository.ExistRecordAsync(id))
            {
                return null;
            }

            return await _repository.GetAsync(id);
        }
    }
}
