using Domain.Models.Service;

namespace Application.UseCases.ServiceCountry
{
    public interface IAddServiceCountryUseCase
    {
        Task<bool> ExecuteAsync(int serviceId, List<ServiceCountryDetailModel> models);
    }
}
