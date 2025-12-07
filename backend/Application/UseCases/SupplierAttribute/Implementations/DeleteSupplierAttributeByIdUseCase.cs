using Application.Ports.RepositoryEntityFrameworkSqlServer;

namespace Application.UseCases.SupplierAttribute.Implementations
{
    public class DeleteSupplierAttributeByIdUseCase : IDeleteSupplierAttributeByIdUseCase
    {
        private readonly ISupplierAttributeRepositoryPort _repository;

        public DeleteSupplierAttributeByIdUseCase(ISupplierAttributeRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            if (!await _repository.ExistRecordAsync(id))
                return;

            var model = await _repository.GetAsync(id);

            if (model != null)
                await _repository.DeleteAsync(model);

            return;
        }
    }
}
