using Application.Ports.RepositoryEntityFrameworkSqlServer;

namespace Application.UseCases.ServiceCountry.Implementations
{
    public class DeleteServiceCountryByIdUseCase : IDeleteServiceCountryByIdUseCase
    {
        private readonly IServiceCountryRepositoryPort _repository;

        public DeleteServiceCountryByIdUseCase(IServiceCountryRepositoryPort repository)
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
