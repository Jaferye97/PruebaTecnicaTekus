using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Service;

namespace Application.UseCases.ServiceCountry.Implementations
{
    public class AddServiceCountryUseCase : IAddServiceCountryUseCase
    {
        private readonly IServiceCountryRepositoryPort _repository;

        public AddServiceCountryUseCase(IServiceCountryRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(int serviceId, List<ServiceCountryDetailModel> models)
        {
            return await _repository.AddAsync(serviceId, models);
        }
    }
}
