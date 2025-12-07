using Domain.Models.Commons;
using Domain.Models.Service;

namespace Application.UseCases.Service
{
    public interface IGetServiceByFiltersUseCase
    {
        Task<PagedResult<ServiceWithCountryModel>> ExecuteAsync(ServiceFilterModel filter);
    }
}
