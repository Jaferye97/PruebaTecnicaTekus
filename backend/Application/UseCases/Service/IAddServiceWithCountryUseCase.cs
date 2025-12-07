using Domain.Models.Service;

namespace Application.UseCases.Service
{
    public interface IAddServiceWithCountryUseCase
    {
        Task<bool> ExecuteAsync(ServiceWithCountryModel model);
    }
}
