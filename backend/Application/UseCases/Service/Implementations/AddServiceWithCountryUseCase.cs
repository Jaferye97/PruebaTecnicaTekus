using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Service;

namespace Application.UseCases.Service.Implementations
{
    public class AddServiceWithCountryUseCase : IAddServiceWithCountryUseCase
    {
        private readonly IServiceRepositoryPort _repository;

        public AddServiceWithCountryUseCase(IServiceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(ServiceWithCountryModel model)
        {
            return await _repository.AddAsync(model);
        }
    }
}
