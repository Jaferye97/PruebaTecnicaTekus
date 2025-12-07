using Domain.Models.Service;
using Domain.Models.Supplier;

namespace Application.UseCases.Service
{
    public interface IGetServiceByIdUseCase
    {
        Task<ServiceWithCountryModel> ExecuteAsync(int id);
    }
}
