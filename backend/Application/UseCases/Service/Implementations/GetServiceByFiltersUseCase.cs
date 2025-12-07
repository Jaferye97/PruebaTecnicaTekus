using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Commons;
using Domain.Models.Service;

namespace Application.UseCases.Service.Implementations
{
    public class GetServiceByFiltersUseCase : IGetServiceByFiltersUseCase
    {
        private readonly IServiceRepositoryPort _repository;

        public GetServiceByFiltersUseCase(IServiceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ServiceWithCountryModel>> ExecuteAsync(ServiceFilterModel filter)
        {
            return await _repository.GetAllAsync(filter);
        }
    }
}
