using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations
{
    public class UpdateSupplierUseCase : IUpdateSupplierUseCase
    {
        private readonly ISupplierRepositoryPort _repository;

        public UpdateSupplierUseCase(ISupplierRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(SupplierModel model)
        {
            if (!await _repository.ExistRecordAsync(model.Id))
            {
                return false;
            }

            return await _repository.UpdateAsync(model);
        }
    }
}
