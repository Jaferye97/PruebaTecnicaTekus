using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Service;

namespace Application.UseCases.Service.Implementations
{
    public class GetServiceByIdUseCase : IGetServiceByIdUseCase
    {
        private readonly IServiceRepositoryPort _repository;

        public GetServiceByIdUseCase(IServiceRepositoryPort repository)
        {
            _repository = repository;
        }

        public async Task<ServiceWithCountryModel?> ExecuteAsync(int id)
        {
            if (!await _repository.ExistRecordAsync(id))
            {
                return null;
            }

            return await _repository.GetAsync(id);
        }
    }
}
