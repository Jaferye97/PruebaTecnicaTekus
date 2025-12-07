using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Service;

namespace Application.UseCases.Service.Implementations
{
    public class UpdateServiceUseCase : IUpdateServiceUseCase
    {
        private readonly IServiceRepositoryPort _repository;

        public UpdateServiceUseCase(IServiceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(ServiceModel model)
        {
            if (!await _repository.ExistRecordAsync(model.Id))
            {
                return false;
            }

            await _repository.UpdateAsync(model);

            return true;
        }
    }
}
